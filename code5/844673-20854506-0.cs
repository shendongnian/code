    MediaItem src = new MediaItem(sourceAudioFile); 
                switch (outputAudioType) 
                { 
                    case OutputAudioType.MP4: 
                        src.OutputFormat = new MP4OutputFormat(); 
                        src.OutputFormat.AudioProfile = new AacAudioProfile(); 
                        src.OutputFormat.AudioProfile.Codec = AudioCodec.AAC; 
                        src.OutputFormat.AudioProfile.BitsPerSample = 24; 
                        break; 
                    case OutputAudioType.WMA: 
                        src.OutputFormat = new WindowsMediaOutputFormat(); 
                        src.OutputFormat.AudioProfile = new WmaAudioProfile(); 
                        src.OutputFormat.AudioProfile.Bitrate = new VariableConstrainedBitrate(128, 192); 
                        src.OutputFormat.AudioProfile.Codec = AudioCodec.WmaProfessional; 
                        src.OutputFormat.AudioProfile.BitsPerSample = 24; 
                        break; 
                } 
     
                TimeSpan spanStart = TimeSpan.FromMilliseconds(startpoint); 
                src.Sources[0].Clips[0].StartTime = spanStart; 
                TimeSpan spanEnd = TimeSpan.FromMilliseconds(endpoint); 
                src.Sources[0].Clips[0].EndTime = spanEnd; 
     
                job.MediaItems.Add(src); 
                job.OutputDirectory = outputDirectory; 
                job.Encode(); 
     
                return job.MediaItems[0].ActualOutputFileFullPath; 
            } 
        } 
 

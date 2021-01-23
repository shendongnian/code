    source = CodecFactory.Instance.GetCodec(ofn.FileName)
                    .Loop()
                   // .ChangeSampleRate(32000)
                    .AppendSource(Equalizer.Create10BandEqualizer, out _equalizer)
                    .ToWaveSource();
                if (source.WaveFormat.SampleRate < 44100) 
                {
                    source.ChangeSampleRate(44100);
                }

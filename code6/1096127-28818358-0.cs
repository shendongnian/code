    using (SpeechSynthesizer synth = new SpeechSynthesizer())
    {
        var voiceStream = await synth.SynthesizeTextToStreamAsync(toSay);
        MediaElement mediaElement; 
        mediaElement = rootControl.Children.FirstOrDefault(a => a as MediaElement != null) as MediaElement;
        if (mediaElement == null)
        {
            mediaElement = new MediaElement();
         
            rootControl.Children.Add(mediaElement);
        }
 
        mediaElement.SetSource(voiceStream, voiceStream.ContentType);
        mediaElement.Volume = 1;
        mediaElement.IsMuted = false;
 
        var tcs = new TaskCompletionSource<bool>();                
        mediaElement.MediaEnded += (o, e) => { tcs.TrySetResult(true); };               
 
        mediaElement.Play();                
 
        await tcs.Task;
 
        // Removing the control seems to free up whatever is locking 
        rootControl.Children.Remove(mediaElement);
 
    }

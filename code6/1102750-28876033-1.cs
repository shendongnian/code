    public int Read(float[] buffer, int offset, int count)
    {
       int sourceSamplesRead = source.Read(buffer, offset, count);
		
       lock (lockObject)
       {
			if (fadeOutDelaySamples > 0)
			{
				fadeOutDelayPosition += sourceSamplesRead / WaveFormat.Channels;
				if (fadeOutDelayPosition >= fadeOutDelaySamples)
				{
					fadeOutDelaySamples = 0;
					fadeState = FadeState.FadingOut;
				}
			}
           if (fadeState == FadeState.FadingIn)
           {
               FadeIn(buffer, offset, sourceSamplesRead);
           }
           else if (fadeState == FadeState.FadingOut)
           {
               FadeOut(buffer, offset, sourceSamplesRead);
           }
           else if (fadeState == FadeState.Silence)
           {
               ClearBuffer(buffer, offset, count);
           }
       }
       return sourceSamplesRead;
    }

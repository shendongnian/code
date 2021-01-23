    /// <summary>
    /// Requests that a fade-out begins (will start on the next call to Read)
    /// </summary>
    /// <param name="fadeDurationInMilliseconds">Duration of fade in milliseconds</param>
    public void BeginFadeOut(double fadeAfterMilliseconds, double fadeDurationInMilliseconds)
    {
		lock (lockObject)
		{
			fadeSamplePosition = 0;
			fadeSampleCount = (int)((fadeDurationInMilliseconds * source.WaveFormat.SampleRate) / 1000);
			fadeOutDelaySamples = (int)((fadeAfterMilliseconds * source.WaveFormat.SampleRate) / 1000);
			fadeOutDelayPosition = 0;
           //fadeState = FadeState.FadingOut;
       }
    }

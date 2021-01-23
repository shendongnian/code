	public class SoundEffectHelper : IDisposable
	{
		public TimeSpan Duration { get; private set; }
		private SoundEffectInstance soundEffect;
    	public SoundEffectHelper(string path)
		{
			using (Stream stream = TitleContainer.OpenStream(path))
			{
				SoundEffect effect = SoundEffect.FromStream(stream);
				this.Duration = effect.Duration;
				this.soundEffect = effect.CreateInstance();
				FrameworkDispatcher.Update();
			}
		}
    		public void Play()
		{
			this.soundEffect.Play();
		}
		public void Stop()
		{
			this.soundEffect.Stop(true);
		}
		public void Pause()
		{
			this.soundEffect.Pause();
		}
		public void Resume()
		{
			this.soundEffect.Resume();
		}
		public void Dispose()
		{
			this.soundEffect.Dispose();
		}
    }

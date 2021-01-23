	public interface IPlayerBase
	{
		IsPlaying { get; set; }
		void Play();
	}
	public interface IVideoPlayerBase : PlayerBase
	{
		void Rotate();
	}
	public interface IAudioPlayerBase : PlayerBase
	{
		void Mute();
	}
	public abstract class AbstractVideoPlayer : IVideoPlayerBase 
	{
		public void Rotate() {
		   // implementation
		}
	}
	public abstract class AbstractAudioPlayer : IAudioPlayerBase 
	{
		public abstract void Mute() {
		   // implementation
		}
	}
	public abstract class VedioAudioPlayerBase : IVideoPlayerBase, IAudioPlayerBase
	{
		IVideoPlayerBase video;
		IAudioPlayerBase audio;
		public void Rotate() {
		   video.Rotate();
		}
		public void Mute() {
		   audio.Mute();
		}
	}

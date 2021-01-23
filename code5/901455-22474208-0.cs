    public interface IPlayer
    {
        bool IsPlaying
        {
            get;
            set;
        }
        void Play();
    }
    public interface IVideoPlayer: IPlayer
    {
        void Rotate();
    }
    public interface IAudioPlayer: IPlayer
    {
        void Mute();
    }
    public interface IAudioVideoPlayer: IVideoPlayer, IAudioPlayer
    {
    }
    public abstract class PlayerBase: IPlayer
    {
        public bool IsPlaying
        {
            get;
            set;
        }
        public abstract void Play();
    }
    public abstract class VideoPlayerBase: PlayerBase, IVideoPlayer
    {
        public abstract void Rotate();
    }
    public abstract class AudioPlayerBase: PlayerBase, IAudioPlayer
    {
        public abstract void Mute();
    }
    public class VideoPlayer: VideoPlayerBase
    {
        public override void Play()
        {
            Console.WriteLine("VideoPlayerBaseImpl:Play()");
        }
        public override void Rotate()
        {
            Console.WriteLine("VideoPlayerBaseImpl:Rotate()");
        }
    }
    public class AudioPlayer : AudioPlayerBase
    {
        public override void Play()
        {
            Console.WriteLine("AudioPlayerBaseImpl:Play()");
        }
        public override void Mute()
        {
            Console.WriteLine("AudioPlayerBaseImpl:Mute()");
        }
    }
    public class AudioVideoPlayer: IAudioVideoPlayer
    {
        public void Rotate()
        {
            _videoPlayer.Rotate();
        }
        public void Mute()
        {
            _audioPlayer.Mute();
        }
        public bool IsPlaying
        {
            get
            {
                return _audioPlayer.IsPlaying && _videoPlayer.IsPlaying;
            }
            set
            {
                _audioPlayer.IsPlaying = value;
                _videoPlayer.IsPlaying = value;
            }
        }
        public void Play()
        {
            _audioPlayer.Play();
            _videoPlayer.Play();
        }
        private readonly AudioPlayer _audioPlayer = new AudioPlayer();
        private readonly VideoPlayer _videoPlayer = new VideoPlayer();
    }

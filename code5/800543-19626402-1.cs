    interface IFileActionHandler
    {
        void PlayFile(IFile file);
    }
    class FileActionHandlerBase : IFileActionHandler
    {
        IApp _app;
        public FileActionHandlerBase(IApp app) // It may not be needed depending on what you want to do.
        {
            _app = app;
        }
        public abstract void PlayFile(IFile file);        
    }
    class AudioFileActionHandler : FileActionHandlerBase
    {
        public AudioFileActionHandler(IApp app)
            : base(app) { }
        public override void PlayFile(IFile file)
        {
            // Your implementation...
        }
    }
    class VideoFileActionHandler : FileActionHandlerBase
    {
        public VideoFileActionHandler(IApp app)
            : base(app) { }
        public override void PlayFile(IFile file)
        {
            // Your implementation...
        }
    }
    public class PlaybackControls
        {
            private MediaPlayer player;
            private int index;
            Dictionary<string, IFileActionHandler> _fileActionHandlers;            
            public PlaybackControls(MediaPlayer player)
            {
                this.player = player;
                _fileActionHandlers = new Dictionary<string, IFileActionHandler>();
                _fileActionHandlers.Add(typeof(VideoFile).Name, new VideoFileActionHandler(player));
                _fileActionHandlers.Add(typeof(AudioFile).Name, new AudioFileActionHandler(player));
            }
            public void Seek(float pos) { }
            public void Next()
            {
                index = (index + 1) % player.Medias.Count;
                player.Current = player.Medias[index];
            }
            public void Previous()
            {
                index--;
                if (index < 0)
                    index = player.Medias.Count - 1;
                player.Current = player.Medias[index];
            }
            public void Play(MediaFile media)
            {
                IsPlaying = true;
                _fileActionHandlers[media.GetType().Name].PlayFile(media);
            }
            public void Play()
            {
                Play(player.Current);
            }
            public void Pause()
            {
                IsPlaying = false;
            }
            public void Stop()
            {
                IsPlaying = false;
                Seek(0);
            }
            public bool IsPlaying { get; private set; }            
        }

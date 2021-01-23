    public class PlaybackControls
        {
            private MediaPlayer player;
            private int index;
            Dictionary<string, Action<MediaFile>> _fileActionMethods;
            public PlaybackControls(MediaPlayer player)
            {
                this.player = player;
                _fileActionMethods = new Dictionary<string, Action<MediaFile>>();
                _fileActionMethods.Add(typeof(VideoFile).Name, x => PlayVideoFile(x));
                _fileActionMethods.Add(typeof(AudioFile).Name, x => PlayAudioFile(x));
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
                _fileActionMethods[media.GetType().Name](media);
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
            private void PlayVideoFile(MediaFile file) { }
            private void PlayAudioFile(MediaFile file) { }
        }

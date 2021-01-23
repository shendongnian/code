    public class AudioComponent : GameComponent
    {
        public enum LevelEffect { BadCollision, GoodCollision, PopUp }
        public enum GameMusic { GameWin, GameLose, GameStart }
        private Song winSound, loseSound, startSound;
        private SoundEffect badCollSound, goodCollSound, popUp;
        public AudioComponent()
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }
        public void loadAudio(
            Song winSound,
            Song loseSound,
            Song startSound,
            SoundEffect badCollSound,
            SoundEffect goodCollSound,
            SoundEffect popUp
            )
        {
            this.winSound = winSound;
            this.loseSound = loseSound;
            this.startSound = startSound;
            this.badCollSound = badCollSound;
            this.goodCollSound = goodCollSound;
            this.popUp = popUp;
        }
        public void PlayGameMusic(GameMusic effType)
        {
            switch (effType)
            {
                case GameMusic.GameWin:
                    PlayMusic(winSound);
                    break;
                case GameMusic.GameLose:
                    PlayMusic(loseSound);
                    break;
                case GameMusic.GameStart:
                    PlayMusicRepeat(startSound);
                    break;
            }
        }
        public void PlayLevelEffect(LevelEffect effType)
        {
            switch (effType)
            {
                case GameMusic.BadCollision:
                    PlayEffect(badCollSound);
                    break;
                case GameMusic.GoodCollision:
                    PlayEffect(goodCollSound);
                    break;
                case GameMusic.PopUp:
                    PlayEffect(popUp);
                    break;
            }
        }
        public void PlayEffect(SoundEffect sound)
        {
            sound.Play();
        }
        public bool CheckAlreadyPlayingMusic()
        {
            return MediaPlayer.State == MediaState.Playing;
        }
        public void PlayMusic(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = false;
        }
        public void PlayMusicRepeat(Song song)
        {
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
        }
        public void StopMusic()
        {
            MediaPlayer.Stop();
        }
        public void PauseMusic()
        {
            MediaPlayer.Pause();
        }
        public void ResumeMusic()
        {
            MediaPlayer.Resume();
        }
        public void ChangeVolume(float volume)
        {
            MediaPlayer.Volume = volume;
        }
    }

    public class MusicPlayer
    {
        public MusicPlayer()
        {
            Play = new Play();
        }
        public Play Play { get; private set; }
    }
    public class Play
    {
        //This one should be called if I want to play one song
        public void Song(String _path){}
        //And this one when I want to play from list, defined in MusicPlayer class
        public void List() { }
    }

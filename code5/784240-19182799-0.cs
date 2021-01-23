    using Nokia.Music.Phone;
    using Nokia.Music.Phone.Tasks;
    
    ...
    
    namespace MusicExplorer
    {
        ...
    
        public class MusicApi
        {
            ...
              
            public void LaunchArtistMix(string artistName)
            {
                ...
    
                PlayMixTask task = new PlayMixTask();
                task.ArtistName = artistName;
                task.Show();
            }
    
            ...
        }
    }

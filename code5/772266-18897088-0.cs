    public class LevelManagerSpawner
    {
        public GameObject[] LevelManagerPrefabs;
        void OnLevelWasLoaded( int levelNumber )
        {
            Instantiate( LevelManagerPrefabs[ levelNumber ] );
        }
    }

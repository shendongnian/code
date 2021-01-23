    private static MusicianDatabase musicianDatabase;
    private static BandDatabase bandDatabase;
    static void Main(string[] args)
    {
        musicianDatabase = new MusicianDatabase();
        bandDatabase = new BandDatabase(musicianDatabase);
    }

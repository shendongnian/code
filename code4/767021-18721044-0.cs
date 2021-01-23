    public class HottestPageProxy
    {
      public HottestPageProxy()
      {
        Artists = NotifyTaskCompletion.Create(GetArtists());
      }
      public INotifyTaskCompletion<ArtistsQuery> Artists { get; private set; }
      private Task<ArtistsQuery> GetArtists()
      {
        string apiKey = App.GetApiKey();
        return Queries.ArtistTopHottt(new ArtistTopHotttParameters
        {
            ApiKey = apiKey,
            Results = 100,
            Buckets = new[] {ArtistTopHotttBuckets.Hotttnesss}
        });
      }
    }

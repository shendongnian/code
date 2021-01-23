    public class ShazamClassFactory
    {
       private string url;
       private IShazamService _shazamService;
    
       public ShazamClassFactory(string url) { this.url = url; }
    
       public void SetShazamService(IShazamService service) {
          _shazamService = service;
       }
    
       public string GetSong(){
          return _shazamService.IdentifySong(url.ToByteArray());
       }
    }

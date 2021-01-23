    public class CoverWrapper
    {
     private Cover cover;
    
     public CoverWrapper()
     {
      cover = new Cover();
     }
    
     public string Description
     {
      get
      {
       return cover.Description;
      }
      set
      {
       cover.Description = value;
      }
     }
    
     public string Peril
     {
      get
      {
       return cover.Perils[0];
      }
      set
      {
       cover.Perils.Add(value);
      }
     }
    
     public GetCover()
     {
      return cover;
     }
    }

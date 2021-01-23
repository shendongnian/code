    session.QueryOver<Sites>()
            .SelectList(x => x
              .Select(p => p.Name)
              .Select(p => p.Lat)
              .Select(p => p.Lng)
            )
            .TransformUsing(Transformers.AliasToBean<MarkerDto>())  
            .List<MarkerDto>();  
    public class MarkerDto  
    {  
      public string Name { get; set; }  
      public decimal? Lat { get; set; }  
      public decimal? Lng { get; set; }  
    }  

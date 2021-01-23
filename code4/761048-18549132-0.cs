    public class TVSerie
    {
    public List<Episode> Episodes{get;set;}
    
    public TVSerie ()
    {
       this.Episodes = new List<Episode>
    }
    }
---
    TVserie breakingBad = new TVserie();
    Episode episode = new Episode();
    episode.Foo = "Foo";
    episode.Bar = "Bar";
    breakingBad.Episodes.Add(episode);

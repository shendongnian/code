    void Main()
    {
      List<cntrydata> result = new List<cntrydata>()
      {
        new cntrydata() { countryid = "USA", countryname = "United States", 
          data = new List<Data>() { 
            new Data() { year = 2000, value = 12 },
            new Data() { year = 2001, value = 22 }, 
            new Data() { year = 2004, value = 32 } 
          }
        },
        new cntrydata() { countryid = "CAN", countryname = "Canada", 
          data = new List<Data>() { 
               new Data() { year = 2001, value = 29 }, 
               new Data() { year = 2003, value = 22 }, 
               new Data() { year = 2004, value = 24 } 
            }
        }
      };
     
      var newresult = result.SelectMany(cntry => cntry.data.Select(d => new { id = cntry.countryid, name = cntry.countryname, year = d.year, value = d.value }))
                            .GroupBy(f => f.year)
                            .Select(g => new { year = g.Key, placeList = g.Select(p => new { p.id, p.value })});
      
      newresult.Dump();
      
    }
    
    public class cntrydata
    {
        public string countryid { get; set; }
        public string countryname { get; set; }
    
        public IEnumerable<Data> data { get; set; }
    
    }
    
    public class Data
    {
            public int year { get; set; }
            public float value { get; set; }
    }

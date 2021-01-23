    Step 1 :Create elastic client
    
    var uri = new Uri("http://localhost:9200");
    var settings = new ConnectionSettings(uri).SetDefaultIndex("my_indexone");
    var client = new ElasticClient(settings);
    client.CreateIndex("my_indexone", s => s.AddMapping<VehicleRecords>(f => f.MapFromAttributes().Properties(p => p.GeoPoint(g => g.Name(n => n.Coordinate ).IndexLatLon()))));
    
    Step 1 :Create below class
                
                  public class VehicleRecords
                    {
                
                        public string name { get; set; }
                        public Coordinate Coordinate { get; set; }
                        public double Distance { get; set; }
                    }
                
                    public class Coordinate
                    {
                        public double Lat { get; set; }
                        public double Lon { get; set; }
                    }
                
              Step 2 :Insert some record using above class
              Step 3 :Using below query to search....
                
            
     Nest.ISearchResponse<VehicleRecords> Response = client.Search<VehicleRecords>(s => s.Sort(sort => sort.OnField(f => f.Year).Ascending()).From(0).Size(10).Filter(fil => fil.GeoDistance(n => n.Coordinate, d => d.Distance(Convert.ToDouble(100), GeoUnit.Miles).Location(73.1233252, 36.2566525))));

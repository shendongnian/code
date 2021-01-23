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

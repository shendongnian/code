    public class District
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    
    public class Thana
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
    
    public class Repository
    {
        public IEnumerable<District> GetDistricts()
        {
            // Dome data
            return new List<District>
            {
                new District {Id = 1, Text = "D1"},
                new District {Id = 2, Text = "D2"}
            };
        }
    
        public IEnumerable<Thana> GetThanas(int districtId)
        {
            // Demo data
            if (districtId == 1)
            {
                return new List<Thana> { new Thana {Id = 1, Text = "T11"}, new Thana {Id = 2, Text = "T12"}};
            }
    
            return new List<Thana> { new Thana {Id = 3, Text = "T21"}, new Thana {Id = 4, Text = "T22"} };
        }
    }

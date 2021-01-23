    List<String> AdminLocation= new List<String>();
    AdminLocation.Add("Location1");
    AdminLocation.Add("Location2");
    AdminLocation.Add("Location3");
    
    AdminLocation.Cast<string>().ToList()
    
    ContactLocations = Locations
        .Where(l => l.Active == "Y").OrderBy(l => l.Name)
        .Select(l => new Location { DbLocation = l, IsChecked = false, IsEnabled = AdminLocation.Contains(l.Name) })
        .ToList();
    
    public class Location    {
        public db.Location DbLocation { get; set; }
        public Boolean IsChecked { get; set; }
        public Boolean IsEnabled { get; set; }
    }

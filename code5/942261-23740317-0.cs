    public class Rayon
        {
            public int idLocation { get; set; }
            public string LocationName { get; set; }
            public List<Rayon> idParentLocation { get; set; }
        }
        public class Livre
        {
            public int id { get; set; }
            public string name { get; set; }
            public string author { get; set; }
            public List<Rayon> Location { get; set; }
        }
    List<Rayon> library = new List<Rayon>();
            library.Add(new Rayon() { idLocation = 1, idParentLocation = null, LocationName = "BookCase1" });
            library.Add(new Rayon() { idLocation = 10, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase1")) }, LocationName = "1Shelf1" });
            library.Add(new Rayon() { idLocation = 11, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase1")) }, LocationName = "1Shelf2" });
            library.Add(new Rayon() { idLocation = 12, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase1")) }, LocationName = "1Shelf3" });
            library.Add(new Rayon() { idLocation = 2, idParentLocation = null, LocationName = "BookCase2" });
            library.Add(new Rayon() { idLocation = 20, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase2")) }, LocationName = "2Shelf1" });
            library.Add(new Rayon() { idLocation = 21, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase2")) }, LocationName = "2Shelf2" });
            library.Add(new Rayon() { idLocation = 22, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase2")) }, LocationName = "2Shelf3" });
            library.Add(new Rayon() { idLocation = 3, idParentLocation = null, LocationName = "BookCase3" });
            library.Add(new Rayon() { idLocation = 30, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase3")) }, LocationName = "3Shelf1" });
            library.Add(new Rayon() { idLocation = 31, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase3")) }, LocationName = "3Shelf2" });
            library.Add(new Rayon() { idLocation = 32, idParentLocation = new List<Rayon>() { library.Find(i => i.LocationName.Equals("BookCase3")) }, LocationName = "3Shelf3" });
            List<Livre> bkList = new List<Livre>();
            bkList.Add(new Livre() { id = 1, name = "Catch-22", author = "Heller", Location = new List<Rayon>() { library.Find(i => i.idLocation == 30) } });
            var test = bkList.SelectMany(b => b.Location.SelectMany(c => c.idParentLocation.Select(p => new { id = b.id, name = b.name, author = b.author, hierarchy = p.LocationName + "->" + c.LocationName + "->" + b.name })));

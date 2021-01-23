     public class Flower {
        public double Radius { get; set; }
        public string Name { get; set; }
     }
     var l = new List<Flower>();
     l.Add(new Flower() { Radius = 4.7, Name = "Iris-setosa" });
     l.Add(new Flower() { Radius = 4.6, Name = "Iris-setosa" });
     /* ... */
     Flower[] sorted = l.OrderBy(f => f.Radius).ToArray();

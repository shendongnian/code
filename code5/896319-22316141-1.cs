    var derp1 = new List<Derp>();
    derp1.Add(new Derp() {strName = "X"});
    derp1.Add(new Derp() { strName = "Y" });
    derp1.Add(new Derp() { strName = "Z" });
    
    var derp2 = new List<Derp>();
    derp2.Add(new Derp() {strName = "A"});
    derp2.Add(new Derp() { strName = "B" });
    derp2.Add(new Derp() { strName = "X" });
    
    
    var derp3 = new List<Derp>();
    derp3.Add(new Derp() { strName = "J" });
    derp3.Add(new Derp() { strName = "B" });
    derp3.Add(new Derp() { strName = "X" });
    
    
    var merged = derp1.Union(derp2.Union(derp3)).Distinct();
    
    Console.WriteLine(merged.Count());   // Returns 6: X, Y, Z, A, B, J

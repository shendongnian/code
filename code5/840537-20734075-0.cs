using SCG = System.Collections.Generic;
public class Bread {
   public class Bread(string name,  string version, int foodValue, int weight) {
      //     ...
   }
}
public class Breads {
   private readonly SCG.List<Bread> breads = new SCG.List<Bread>();
   public void AddBread(Bread bread) {
      breads.Add(bread);
   }
   public SCG.IEnumerable<Bread> Breads {
      get { return breads; }
   }
}

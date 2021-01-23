    public enum Fabric { Cotton, Silk, Poly }
    public abstract Garment{
  
        public Fabric Fabric {get; set; }
    }
    class Buttons
    {
      Color color {get;set;}
      Shape shape {get;set;}
    }
    class Zip
    {
       Color color {get;set;}
       Size size {get;set;}
    }
    public class Shirt : Garment{
       public Buttons Buttons { get; set;} 
    }
    public class Pants : Garment{
      public Zip Zip { get; set;}
    }

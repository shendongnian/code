    public class Car
    {
       public static Car CreateNew()
       {
          Car c = new Car();
          c.Engine = Engine.CreateNew(4);  // 4 cyl
          //set properties so that the object will behave correctly...
          return c;
       }
       public static Car CreateNew(string make, string model, Engine e)
       {
         Car c = new Car(make,model);
         c.Engine = e;
       }
       private Car(){
       }
   
       private Car( string make, string model) : this() {
          Make = make;
          Model = model;
       }
       public string Make { get; set; }
       public string Model {get; set; }
       public Engine {get; private set; }
       //other properties that maybe are not so simple or understood
       //or properties that need to be set to control other behaviors..
    }

       class Instructor: Person {
         // From Person abstract class
         public override Position Position 
         {
           get { return new Position(1, 1); }
         }
    
         // Explicit interface implementation
         Position IHasPosition.Position 
         {
           get { ... }
         }
       }

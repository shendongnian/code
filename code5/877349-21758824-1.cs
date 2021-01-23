    public abstract class ShapeDecorator : Shape {
         protected Shape Shape {get; private set;}
         protected(Shape shape) {
              this.Shape = shape;
         }
    }
    public abstract class EllipseDecorator : ShapeDecorator {
          protected(Ellipse ellipse) : base(shape) {
          }
          public Ellipse Ellipse { get { (Ellipse)base.Shape; } }
     
          // Here, if you wish, you can override some methods using Ellipse features inside
          // So that your Shape acts as Ellipse
    }
    public class Ball : EllipseDecorator {
        public Ball() : base(new Ellipse()) {
             // you can initialize base.Ellipse here
        }
         
        // Now you can add your Ball specific methods here
        // You can still override some methods here
        // So that your ellipse acts as Ball
    }

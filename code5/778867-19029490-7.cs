    public class PosTypeAdorner : Adorner
    {
         private string _posText;
 
         // Be sure to call the base class constructor. 
         public PosTypeAdorner (UIElement adornedElement, string posText) : base(adornedElement) 
         { 
               _posText = posText;
         }
         // A common way to implement an adorner's rendering behavior is to override the OnRender 
         // method, which is called by the layout system as part of a rendering pass. 
         protected override void OnRender(DrawingContext drawingContext)
         {
              // Draw the red triangle with it's text using the drawingContext here
         }
     }

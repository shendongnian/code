    public class PosTypeAdorner : Adorner
    {
         // Be sure to call the base class constructor. 
         public PosTypeAdorner (UIElement adornedElement) : base(adornedElement) 
         { 
         }
         // A common way to implement an adorner's rendering behavior is to override the OnRender 
         // method, which is called by the layout system as part of a rendering pass. 
         protected override void OnRender(DrawingContext drawingContext)
         {
              // Draw the red triangle using the DrawContext 
         }
     }

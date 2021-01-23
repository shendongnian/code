    using Autodesk.AutoCAD.Runtime;
    using Autodesk.AutoCAD.ApplicationServices;
    using Autodesk.AutoCAD.DatabaseServices;
    using Autodesk.AutoCAD.GraphicsInterface;
    namespace MyFirstOverrule
    {
        // This is our custom DrawableOverrule class.
        // In this case we're just overruling WorldDraw
    public class MyDrawOverrule : DrawableOverrule
    {
        public override bool WorldDraw(Drawable drawable, WorldDraw wd)
        {
            // Cast Drawable to Line so we can access its methods and
            // properties
            Line ln = (Line)drawable;
            // Draw some graphics primitives
            wd.Geometry.Circle(ln.StartPoint + 0.5 * ln.Delta, ln.Length / 5, ln.Normal);
            // In this case we don't want the line to draw itself, nor do
            // we want ViewportDraw called
            return true;
        }
    }
    public class Commands
    {
        //Shared member variable to store our Overrule instance
        private static MyDrawOverrule _drawOverrule;
        [CommandMethod("TOG")]
        public static void ToggleOverrule()
        {
            // Initialize Overrule if first time run
            if(_drawOverrule == null)
            {
                _drawOverrule = new MyDrawOverrule();
                Overrule.AddOverrule(RXObject.GetClass(typeof(Line)), _drawOverrule, false);
                Overrule.Overruling = true;
            }
            else
            {
                // Toggle Overruling on/off
                Overrule.Overruling = !Overrule.Overruling;
            }
            // Regen is required to update changes on screen
            Application.DocumentManager.MdiActiveDocument.Editor.Regen();
        }
        }
    }

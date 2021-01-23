    namespace ControlCenter
    {
        public partial class Canvas
        {
            
            public Canvas
            {
              InitialiseComponent();
              addLayer.myCanvas = this;
    
            }
    
            public void display(string itemID)
            {
                ... // here assign some properties to the item
                this.Children.Add(item);
            }
        }
    }
    namespace ControlCenter
    {
        public static class addLayer
        {
            private static ControlCenter.Canvas myCanvas;
    
            public static void add()
            {
                myCanvas.display("1234");
            }
        }
    }

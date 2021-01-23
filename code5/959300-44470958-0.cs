    class Control1 : UIElement {
        DrawingGroup backingStore = new DrawingGroup();
    
        protected override void OnRender(DrawingContext drawingContext) {      
            base.OnRender(drawingContext);            
    
            Render(); // put content into our backingStore
            drawingContext.DrawDrawing(backingStore);
        }
        private void Render() {            
            var drawingContext = backingStore.Open();
            Render(drawingContext);
            drawingContext.Close();            
        }
        private void Render(DrawingContext) {
            // put your existing drawing commands here.
        }
    }
    class Control2 : UIElement {
        DrawingGroup backingStore = new DrawingGroup();
    
        protected override void OnRender(DrawingContext drawingContext) {      
            base.OnRender(drawingContext);            
    
            Render(); // put content into our backingStore
            drawingContext.DrawDrawing(backingStore);
        }
        private void Render() {            
            var drawingContext = backingStore.Open();
            Render(drawingContext);
            drawingContext.Close();            
        }
        private void Render(DrawingContext) {
            // put your existing drawing commands here.
        }
    }
    
    class SomeOtherClass {
        public void SomeOtherMethod() {
             control1.Render();
             control2.Render();
        }
    }    
    

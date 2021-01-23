    public class GraphicsSpy : IGraphics
    {
        public void Draw()
        {
            DrawCalled = true;
        }
        public bool DrawCalled{get;private set;}
    }

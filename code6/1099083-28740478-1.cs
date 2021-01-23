    public class MoveVisitor : IVisitor
    {
        private int dx;
        private int dy;
        
        public MoveVisitor(int dx, int dy)
        {
             this.dx = dx;
             this.dy = dy;
        }
        public void Visit(IShape shape)
        {
             shape.Move(dx,dy);
        }
    }

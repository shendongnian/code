    public interface IShape
    {
        void Resize(PosSizableRect posSizableRect, float lastX, float lastY, float newX, float newY);
        void Move(int dx, int dy);
        void Write (StreamWriter writer, string tabs ="");
        void AcceptVisitor(IVisitor visitor);
    }
   
    public interface IVisitor
    {
        void Visit(IShape shape);
    }

    internal interface IShape
    {
        void Draw();
    }
    internal class Rectangle : IShape
    {
        public void Draw() { }
    }
    internal class Square : Rectangle, IShape
    {
        public new void Draw() { }
    }

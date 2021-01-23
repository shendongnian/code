    public partial class Form1 : Form
    {
        private List<IDrawAble> shapes = new List<IDrawAble>();
        private MyEllipse currentlyDrawing;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            currentlyDrawing = new MyEllipse() { X1 = e.X, Y1 = e.Y, X2 = e.X, Y2 = e.Y };
            Invalidate();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            shapes.Add(currentlyDrawing);
            currentlyDrawing = null;
            Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            foreach (var item in shapes)
            {
                item.Draw(e.Graphics);
            }
            if (currentlyDrawing != null)
            {
                currentlyDrawing.Draw(e.Graphics);
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (currentlyDrawing != null)
            {
                currentlyDrawing.X2 = e.X;
                currentlyDrawing.Y2 = e.Y;
                Invalidate();
            }
        }
    }
    class MyEllipse : IDrawAble
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), X1, Y1, X2 - X1, Y2 - Y1);
        }
    }
    interface IDrawAble
    {
        void Draw(Graphics g);
    }

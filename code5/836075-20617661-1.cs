    public Form1()
    {
        InitializeComponent();
        rectangles = new List<Rectangle>();
        panel1.Paint += panel1_Paint;
    }
    public void PopuplateTable(int x, int y)
    {
        rectangles.Add(new Rectangle(x,y, 100, 40));
        //Forces a redraw to happen.
        panel1.Invalidate();
    }
    private List<Rectangle> rectangles; 
    void panel1_Paint(object sender, PaintEventArgs e)
    {
        foreach (var rectangle in rectangles)
        {
            using (var b = new SolidBrush(Color.DarkCyan))
            {
                e.Graphics.FillRectangle(b, rectangle);
            }
        }
    }

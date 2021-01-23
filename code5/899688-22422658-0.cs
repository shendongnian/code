    private readonly List<Point> imageLocations = new List<Point>();
    private readonly List<Image> images = new List<Image>();
    public Form1()
    {
        InitializeComponent();
        // Add 1 empty image...
        images.Add(new Bitmap(100, 100));
        // ...and its location on the form.
        imageLocations.Add(new Point(10, 10));
    }
    private void Form1_MouseUp(object sender, MouseEventArgs e)
    {
        int i = 0;
        foreach (Image image in images)
            if (new Rectangle(imageLocations[i++], image.Size).Contains(e.Location))
                MessageBox.Show("Clicked on image.");
    }
    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        using (Graphics g = e.Graphics)
        {
            int i = 0;
            foreach (Image image in images)
                g.DrawImage(image, imageLocations[i++]);
        }
    }

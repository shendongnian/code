     public Form2() {
        InitializeComponent();
        //creates items for combobox brush sizes
        for (int i = 1; i <= 20; i++)
        {
            string[] numbers = { i.ToString() };
            comboBox1.Items.AddRange(numbers);
        }
        //initialize a blank image for your PictureBox
        pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        g = Graphics.FromImage(pictureBox1.Image);
     }
     Graphics g;
    SolidBrush color = new SolidBrush(Color.Black);
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e) {
        if (e.Button == MouseButtons.Left) {
            int brushSize = comboBox1.SelectedIndex > 0 ?
                            Convert.ToInt32(comboBox1.SelectedItem) : 10;
            g.FillEllipse(color, e.X, e.Y, brushSize, brushSize);
            pictureBox1.Invalidate();//This is important to re-draw the updated Image
        }
    }
    //button that opens colour dialog box
    private void button1_Click_1(object sender, EventArgs e) {
        ColorDialog cld = new ColorDialog();
        if (cld.ShowDialog() == DialogResult.OK) {
            color = new SolidBrush(cld.Color);
        }
    }
    //Button that clears pictureBox
    private void Button2_Click_1(object sender, EventArgs e) {
        g.Clear(pictureBox1.BackColor);
    }
    private void button3_Click(object sender, EventArgs e) {
        pictureBox1.Image.Save(@"C:\New folder\picture.jpg", ImageFormat.Jpeg);
    }

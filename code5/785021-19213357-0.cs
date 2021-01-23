    private void pictureBox1_Click(object sender, EventArgs e)
    {
        MouseEventArgs eM = (MouseEventArgs)e;
        textBox1.Text = eM.X.ToString();
        textBox2.Text = eM.Y.ToString();
        Console.WriteLine("mouse up");
    }

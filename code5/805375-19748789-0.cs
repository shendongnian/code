    int row = Convert.ToInt32(textBox1.Text);
    int column = Convert.ToInt32(textBox2.Text);
    flowLayoutPanel1.Width = (row * 50) + 30;
    flowLayoutPanel1.Height = (column * 50) + 1;
    System.Drawing.Graphics graphics = flowLayoutPanel1.CreateGraphics();
    graphics.Clear(Form1.ActiveForm.BackColor);
    for (int j = 0; j < column; j++)
    {
        for (int i = 0; i < row; i++)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(50 * i, 50 * j, 50, 50);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);
        }
    }

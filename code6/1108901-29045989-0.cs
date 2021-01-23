    Form form2 = new Form();
    form2.Show();
    var graphics = form2.CreateGraphics();
    var rectangle = new System.Drawing.Rectangle(100, 100, 200, 200);
    graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
    graphics.DrawRectangle(System.Drawing.Pens.Red, rectangle);

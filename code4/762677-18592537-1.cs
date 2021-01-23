    public Bitmap ControlToBitmap(Control ctrl)
    {
        Bitmap image = new Bitmap(ctrl.Width, ctrl.Height);
        //Create form
        Form f = new Form();
        //add control to the form
        f.Controls.Add(ctrl);
        //set the size of the form to the size of the control
        f.Size = ctrl.Size;
        //draw the control to the bitmap
        ctrl.DrawToBitmap(image, new Rectangle(0, 0, ctrl.Width, ctrl.Height));
        //dispose the form
        f.Dispose();
        return image;
    }

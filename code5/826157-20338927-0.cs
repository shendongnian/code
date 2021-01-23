    for (int a = 1; a <= 10; a++)
    {
        string name = "pic" + a;
        PictureBox pic = (PictureBox)(this.Controls.Find(name, true))[0];
        pic.DataBindings.Add("ImageLocation", this.mainTableBindingSource, "localPic3");
    }

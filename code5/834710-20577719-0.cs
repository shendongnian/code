    for (int i=1; i< 4;i++)
    {
        Control control = Page.FindControl(string.Format("Image{0}", i));
        if (control != null)
        {
            control.ImageUrl = "(path of the folder)"+i.ToString()+".jpg";
        }
    }

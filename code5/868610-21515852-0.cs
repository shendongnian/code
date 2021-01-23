    if (currentpage == 1)
    {
        for(int i = 1; i<10; i++)
        {
            string[] beitrag = result.Split(new string[] { "<split_inner>" }, StringSplitOptions.None);
            Control imgControl = FindControl(string.Format("profile_img_{0}", i));
            imgControl.Source = (ImageSource)new ImageSourceConverter()
                                     .ConvertFromString("EXAMPLE.jpg);
        }
    }

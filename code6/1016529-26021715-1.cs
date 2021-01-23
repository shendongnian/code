    if (result.GetPicture() != null)
    {
         bmp2.SetSource(result.GetPicture());
    }
    else
    {
         bmp2.SetSource(Application.GetResourceStream(new Uri(@"/Images/ci2.png", UriKind.Relative)).Stream);
    }

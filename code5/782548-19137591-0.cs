    If page.Height > page.Width 
    {
        //Portrait
        page.Orientation = 1;
    }
    Else
    {
        //Landscape
        page.Orientation = 2; 
    }
    page.Print();

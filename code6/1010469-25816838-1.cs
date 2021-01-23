    MainPage()
    {
        DoSomethingToImages(LayoutRoot);
    }
    DoSomethingToImages(Panel panel)
    {
        foreach(Image img in panel.Children.Where(x=> x is Image))
        {
            DoSomething(img);
        }
        var panels = panel.Children.Where(x=> x is Panel);
        if (panels.Count > 0)
        {
            foreach(Panel p in )
            {
                DoSomethingToImages(p);
            }
        }
    }

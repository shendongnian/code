    void GridView_ItemClicked(object sender, EventArgs args)
    {
        var item = (Item)args.ClickedItem;
    
        if (item.Link == "/Page_1.xaml")
            ((Frame)Window.Current.Content).Navigate(typeof (Page_1));
        else if (item.Link == "/Page_2.xaml")
            ((Frame)Window.Current.Content).Navigate(typeof (Page_2));
        else if (item.Link == "/Page_3.xaml")
            ((Frame)Window.Current.Content).Navigate(typeof (Page_3));
    }

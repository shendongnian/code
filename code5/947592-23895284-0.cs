    private async void someEvent(object sender, ItemClickEventArgs e)
    {
        if (await Kérdés.Egyszerű("SURE?", "Are you sure, blablabla?", "YES", "NO") 
            == "YES")
        {
            //stuff
        }
    }

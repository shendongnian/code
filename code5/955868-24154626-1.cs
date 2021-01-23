    private async void Button1_OnClick(object sender, EventArgs e)
    {
        try
        {
            var test = new performance("http://www.example.com");
    
            //The code now waits here for the function to finish.
            await InsertItem(test);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.StackTrace);
        }
    }

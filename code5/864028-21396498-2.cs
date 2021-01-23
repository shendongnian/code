    async void Button_Click(object sender, EventArg e)
    {
        try
        {
            await MyMainMethod();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

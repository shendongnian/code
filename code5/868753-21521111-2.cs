    async void Button_Click(object sender, EventArgs e)
    {
        try
        {
            int resut = await Task.Factory.StartNew<int>(() => { return div(32, 0); });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message)
        }
    }

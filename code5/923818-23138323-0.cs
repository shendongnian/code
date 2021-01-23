    public async void StartTimer()
    {
        while (true)
        {
            string text = textBox1.Text;
            lblTotalImages.Text = await Task.Run(() =>
                AppHelper.GetTotalCount(text).ToString());
            if (sitename != null)
            {
                lblTotalPosted.Text = await Task.Run(() =>
                    AppHelper.GetPostedCount(sitename).ToString());
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
        }
    }

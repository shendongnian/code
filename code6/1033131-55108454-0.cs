    private static void DisableSizeToContent(object sender, EventArgs e)
    {
        if (sender is Window win)
        {                
            win.SizeToContent = SizeToContent.Manual;
        }
    }

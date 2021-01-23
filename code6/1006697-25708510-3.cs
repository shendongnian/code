    // in YourPageClass code
    private void closebt_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (main != null)
        {
            main.Exitbt_PreviewKeyDown(main.Exitbt, e);
            main.Close();
        }
    }

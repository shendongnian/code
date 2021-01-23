    private void closebt_MouseDown(object sender, MouseButtonEventArgs e)
    {
        MainWindow main = Application.Current.MainWindow as MainWindow;
        if (main != null)
        {
            main.Exitbt_PreviewKeyDown(main.Exitbt, e);
            main.Close();
        }
    }

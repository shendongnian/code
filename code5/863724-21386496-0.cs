    private xamlHelp help = null;
    private void btnHelp_Click(object sender, RoutedEventArgs e)
    {
        if (help != null)
        {
            help.Close();
            help = null;
        }
        else
        {
            help = new xamlHelp();
            help.Show();
        }
    }

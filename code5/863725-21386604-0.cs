    private xamlHelp help = new xamlHelp();
    private bool showingHelp = false;
    private void btnHelp_Click(object sender, RoutedEventArgs e)
    {
        if (showingHelp)
        {
            help.Hide();
        }
        else
        {
            help.Show();
        }
    }

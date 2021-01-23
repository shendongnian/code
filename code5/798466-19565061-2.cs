    private void _dt_Tick(object s, EventArgs e)
    {
        DoSomething();
    }
    private void DoSomething()
    {
        try
        {
            ...
        }
        catch (Exception _ex)
        { 
            MessageBox.Show(_ex.ToString(), "Error in Timer", MessageBoxButton.OK, 
                MessageBoxImage.Error); 
        }
    }
    private void button1_Click(object sender, RoutedEventArgs e)
    {
        DoSomething();
    }

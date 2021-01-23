    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        var b = e.OriginalSource as System.Windows.Controls.Button;
        var w = b.TemplatedParent as Window;
        w.Close();
    }

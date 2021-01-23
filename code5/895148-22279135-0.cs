    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        List<string> lst = new List<string>();
        lst.Add("Documnet Pickup");
        lst.Add("Document Submission");
        lst.Add("Others");
        ListBox1.ItemsSource = lst;
        ListBox1.Items[0].Selected = true;
    }

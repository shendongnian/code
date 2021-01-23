    void OnDependencyChange(object sender, SqlNotificationEventArgs e)
    {
        // Handle the event (for example, invalidate this cache entry).
        MessageBox.Show("ikjkjkj");
        Debug.WriteLine("fkldjkfjklgjf");
       SqlDependency dependency =
        (SqlDependency)sender;
        dependency.OnChange -= OnDependencyChange;
        SomeMethod(); //re-register
    }

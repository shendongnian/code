    private void DivideButton_Click(object sender, RoutedEventArgs e) {
        var button = (Button)e.Source;  // <-- the specific button that was clicked
        var c1 = (class1)button.DataContext;  // <-- the instance bound to this button
        c1.Divide();
    }

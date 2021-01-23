    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var parent = (sender as Button).Parent;
        TextBox firstOne = parent.GetChildrenOfType<TextBox>().First(x => x.Name == "firstBox");
        Debug.WriteLine(firstOne.Text);
    }

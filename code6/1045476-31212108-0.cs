     private void ButtonSelectAll_Click(object sender, RoutedEventArgs e)
     {
        MyTextBox.Select(0, MyTextBox.Text.Length);
        string selectedText = MyTextBox.SelectedText;
        DataPackage myPackage = new DataPackage();
        myPackage.SetText(selectedText);
        Clipboard.SetContent(myPackage);
     }

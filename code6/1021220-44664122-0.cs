    private void grdTest_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.V && (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
        {
            TestList.Insert(TestList.IndexOf((Test)grdTest.SelectedItem), copiedItem);
        }
    }

    private void Submit_Click(object sender, RoutedEventArgs e)
    {
        if (stackPanel1.BindingGroup.CommitEdit())
        {
            MessageBox.Show("Item submitted");
            stackPanel1.BindingGroup.SubmitEdit();
        }
    }

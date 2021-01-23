    private void Content_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!txtName.Text.Equals(String.Empty) && txtPass.Password.Equals(txtConfirmPass.Password))
            btSave.IsEnabled = true;
        else
            btSave.IsEnabled = false;
    }

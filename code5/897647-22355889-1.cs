    if (string.IsNullOrWhiteSpace(NameTextBox.Text))
    {
        MessageBox.Show("Please enter a valid name for the motorist", "Error Message", MessageBoxButtons.OK);
    
        sb.Clear();
        sb.Append(currentTime);
        sb.AppendLine(" **Error** failed to enter a valid name");
        ActivityrichTextBox.Text = ActivityrichTextBox.Text + sb.ToString();
        return;
    }

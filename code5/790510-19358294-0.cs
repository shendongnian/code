    string[] blogMessageArray = File.ReadAllLines("");
    blogPostTextBox.Text = "";
    foreach (string message in blogMessageArray)
    {
        blogPostTextBox.Text += message + Environment.NewLine;
    }

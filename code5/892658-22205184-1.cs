    private void SearchButton_Click(object sender, EventArgs e)
    {
        SearchID = int.Parse(searchTextBox.Text);
        string[] lines = File.ReadAllLines(@"C:\Users\Public\TestFolder\"+SearchID+".txt");
        System.Windows.Forms.MessageBox.Show(string.Join("\r\n", lines));
    }

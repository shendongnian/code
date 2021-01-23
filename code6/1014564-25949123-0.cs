    private void label_Click(object sender, EventArgs e)
    {
        Label clickedLabel = sender as Label;
        if(clickedLabel == null)
            return;
        clickedLabel.Text = "clicked"; //pseudo code
    }

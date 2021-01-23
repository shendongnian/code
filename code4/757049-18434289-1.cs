    TextBox[][] textboxes = ...
    private void reset_Click(object sender, EventArgs e)
    {
        for(int i = 0; i < textboxes.Length; i++)
        {
            for (int j = 0; j < textboxes[i].Length; j++)
            {
                textboxes[i][j].Text = "";
            }
        }
    }

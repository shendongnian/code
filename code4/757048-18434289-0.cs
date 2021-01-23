    TextBox[,] textboxes = ...
    private void reset_Click(object sender, EventArgs e)
    {
        for(int i = 0; i < textboxes.GetLength(0); i++)
        {
            for (int j = 0; j < textboxes.GetLength(1); j++)
            {
                textboxes[i,j].Text = "";
            }
        }
    }

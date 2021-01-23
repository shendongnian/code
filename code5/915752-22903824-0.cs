    void addButton_Click(object sender, EventArgs e)
    {
        int contaniners = 0;
        int.TryParse(txtContainers.Text, out contaniners);
        
        for (int i = 0; i < contaniners; i++)
        {
            flowLayoutPanel.Controls.Add(new MyUserControl());
        }
    }

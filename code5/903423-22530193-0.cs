    private void addLabelButton_Click(object sender, EventArgs e)
    {
        Label label = new Label();
        label.Text = DateTime.Now.ToLongTimeString();
        label.DoubleClick += label_DoubleClick;
        labelsFlowLayoutPanel.Controls.Add(label);
    }
    void label_DoubleClick(object sender, EventArgs e)
    {
        Label label = (Label)sender;
        labelsFlowLayoutPanel.Controls.Remove(label);
        label.DoubleClick -= label_DoubleClick;
    }

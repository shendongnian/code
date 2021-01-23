    public string filename { get; set; }
    private void confirmButton_Click(object sender, EventArgs e)
    {
        SaveFileDialog ofd = new SaveFileDialog();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            //DO STUFF WITH SELECTED FILE
        }
        filename = ofd.FileName;
    }

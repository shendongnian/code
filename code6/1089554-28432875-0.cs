    private FileInfo sourceFile;
    private void btnLoad_Click(object sender, EventArgs e)
    {
        sourceFile = new FileInfo(tbSourceFile.Text);
    }
    private void btnNew_Click(object sender, EventArgs e)
    {
        sourceFile.CopyTo(tbDestFile.Text);
    }

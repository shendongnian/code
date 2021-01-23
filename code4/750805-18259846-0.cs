    bool updatePictureBox = true;
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        if(updatePictureBox)
            pictureBox1.Image = btm;
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        updatePictureBox = false;
        DialogResult dr = MessageBox.Show(this,"Exit?", "Exit", MessageBoxButtons.YesNo);
        if (dr == DialogResult.No) e.Cancel = true; else e.Cancel = false;
    }

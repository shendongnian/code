    private void startAllSequenceToolStripMenuItem_Click(object sender, EventArgs e)
    {
        OpenFileDialog ofn = new OpenFileDialog();
        DialogResult result = ofn.ShowDialog();
        if (result == DialogResult.Ok)
        {
            MessageBox.Show("do stuff");
        }
        // This one line seems to allow my application to exit cleanly in debug and release.
        // But I don't instantiate a new object.
        // I used the control on the form and called Dispose from form_closing.
        ofn.Dispose();
    }

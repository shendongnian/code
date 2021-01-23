    myForm newMyForm;
    private void undoToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if(newMyForm == null)
        {
            newMyForm = new myForm();
            newMyForm.MdiParent = this;
            newMyForm.Show();
        }
        else
        {
            newMyForm.Activate();
            newMyForm.Undo();
        }
    }

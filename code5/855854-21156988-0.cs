    this.listView.KeyDown+= new System.Windows.Forms.KeyPressEventHandler(this.listView_KeyDown);
    private void listView_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            DeleteContact();
        }
    }

    BackgroundWorker changeformtext = new BackgroundWorker();
    public Form1()
    {
        InitializeComponent();
        changeformtext.DoWork += changeformtext_DoWork;
    }
    void changeformtext_DoWork(object sender, DoWorkEventArgs e)
    {
        Invoke(new Action(doit));
    }
    void doit()
    {
        this.Text = "Untitled - PadNotePro";
    }
    private void New()
    {
        if (us == true)
        {
            DialogResult dr = MessageBox.Show("Do you want to save changes to: Untitled?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
                Save();
            else if (dr == DialogResult.No)
            {
                changeformtext.RunWorkerAsync();
            }
            else if (dr == DialogResult.Cancel)
                Close();
        }
        else
        {
            changeformtext.RunWorkerAsync();
        }
    }

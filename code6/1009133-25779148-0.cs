    Form parentForm = null;
    private void ParentForm_KeyUp(object sender, KeyEventArgs e)
    {
        MessageBox.Show("HI");
    }
    
    protected override void OnHandleCreated(EventArgs e)
    {
        if (DesignMode)
            return;
    
        base.OnHandleCreated(e);
        object parent = this;
        while (true)
        {
            parent = ((Control)parent).Parent;
            if (parent.GetType().BaseType.Name == "Form")
                break;
        }
        parentForm = (Form)parent;
        parentForm.KeyUp -= new KeyEventHandler(this.ParentForm_KeyUp);
        parentForm.KeyUp += new KeyEventHandler(this.ParentForm_KeyUp);
    }

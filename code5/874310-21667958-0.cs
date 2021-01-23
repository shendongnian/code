    //button to call function that looks for DatagridView control
    private void button2_Click(object sender, EventArgs e)
    {
        scanDG(this);
    }
    
    private void scanDG(Control parent)
    {
        foreach (Control ctrl in parent.Controls)
        {
            if (ctrl.GetType().Name == "DataGridView")
            {//If current Control is Datagridview then set Readonly to true
                ((DataGridView)ctrl).ReadOnly = true;
            }
            //If a control can contain control scan it and look for Datagridview control
            if (ctrl.HasChildren) scanDG(ctrl);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ArrayList txtTesting = ArrayList();
        LoopControls(controls, this.Controls);
        foreach (TextBox txt in txtTesting)
        {
            if (txt.text != "")
            {
                //
            }
        }
    }
    
    private void LoopControls(ArrayList list, Control.ControlCollection controls)
    {
        foreach (Control control in controls)
        {
            if (control is TextBox && control.Name.StartsWith("txtTesting"))
                list.Add(control);
            if (control.Controls.Count > 0)
                LoopControls(list, control.Controls);
        }
    }

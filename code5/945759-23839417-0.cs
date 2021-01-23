    foreach(Control ctrl in this.Controls)
    {
        if(ctrl is IButtonControl)
        {
            ctrl.Enabled = true;
        }
    }

    void ctrl_LostFocus(object sender, EventArgs e)
    {
        var ctrl = sender as Control;
        if (ctrl.Tag is Color)
            ctrl.BackColor = (Color)ctrl.Tag;
    }
    void ctrl_GotFocus(object sender, EventArgs e)
    {
        var ctrl = sender as Control;
        ctrl.Tag = ctrl.BackColor;
        ctrl.BackColor = Color.Red;
    }

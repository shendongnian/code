    if (value == "Value1")
    {
        newLabel.MouseHover += delegate (object sender, MouseEventArgs e)
        {
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.ShowAlways = true;
            ToolTip1.Show("t", newLabel);
        };
    }

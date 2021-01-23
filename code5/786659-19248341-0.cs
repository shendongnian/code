    public void CopyControls()
    {
        List<Control> ctrls = new List<Control>();
        foreach (Control c in this.Controls)
        {
            ctrls.Add(c);
        }
        this.Controls.Clear();
        form2.Controls.AddRange(ctrls.ToArray());
    }

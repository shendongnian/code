    public static void ShowModalForm(Form f, Control parent)
    {
        if (parent.InvokeRequired)
        {
            ShowModalFormCallback d = new ShowModalFormCallback(ShowModalForm);
            parent.Invoke(d, new object[] { f, parent });
        }
        else
        {
            f.ShowDialog(parent);
        }
    }

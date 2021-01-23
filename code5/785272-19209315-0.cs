    public Control DelCon(string name)
    {
        Control c = panel1.Controls[name];
        panel1.Controls.RemoveByKey(name);//Using RemoveByKey is the best choice
        return c;
    }

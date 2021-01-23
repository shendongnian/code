    public int CreateIndexFromCheckboxSelected()
    {
        int chk1 = (CheckBox1.Checked ? 1 : 0);
        int chk2 = (CheckBox2.Checked ? 2 : 0);
        int chk3 = (CheckBox3.Checked ? 4 : 0);
        int chk4 = (CheckBox4.Checked ? 8 : 0);
        return (chk1 + chk2 + chk3 + chk4);
    }

    // In Form1
        frm = new Form2();
        frm.TeamInfoChanged += new Action<string>(frm_TeamInfoChanged);
        frm.Show();
    ...
    void frm_TeamInfoChanged(string info)
    {
        Team1Lbl.Text = info;
    }

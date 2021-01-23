    public void adornQM(Control ctl)
    {
        Label QM = new Label();
        QM.Text = "?";
        QM.Font = new Font("Arial", 6f, FontStyle.Regular);
        QM.BackColor = Color.Yellow;
        QM.Location = new Point(ctl.Width - 8, 0);
        ctl.Controls.Add(QM);
    }

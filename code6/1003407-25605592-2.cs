    public void adornQM(Control ctl)
    {
        Label QM = new Label();
        QM.Font = new Font("Arial", 7f, FontStyle.Regular);
        QM.Location = new Point(ctl.Width - 13, 0);
        QM.Paint += QM_Paint;
        ctl.Controls.Add(QM);
    }
    void QM_Paint(object sender, PaintEventArgs e)
    {
        Label  QM = sender as Label;
        e.Graphics.FillEllipse(Brushes.Yellow, 0, 0, 12, 12);
        e.Graphics.DrawEllipse(Pens.DarkSlateBlue, 0, 0, 12, 12);
        e.Graphics.DrawString("?", QM.Font, Brushes.Black, 2, 1);
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        initMenu(tabControl1, flp_menu);
    }
    void initMenu(TabControl TAB, FlowLayoutPanel FLP)
    {
        FLP.Location = TAB.Location;
        FLP.Width = TAB.Width;
        FLP.Height = TAB.ItemSize.Height + 1;
        RadioButton bt;
        foreach (TabPage tp in TAB.TabPages)
        {
            bt = new RadioButton();
            bt.Appearance = Appearance.Button;
            bt.FlatStyle = FlatStyle.Flat;
            bt.FlatAppearance.CheckedBackColor = Color.Gold;
            // if you color-code the pages this may be nice, too:
            // bt.FlatAppearance.CheckedBackColor = tp.BackColor;
            bt.Image = imageList1.Images[tp.ImageIndex];
            bt.ImageAlign = ContentAlignment.MiddleLeft;
            bt.TextAlign = ContentAlignment.MiddleRight;
            bt.Margin = new Padding(4, 2, 0, 0);
            bt.Text = "       " + tp.Text + "   ";
            bt.AutoSize = true;
            bt.Tag = tp;
            FLP.Controls.Add(bt);
            bt.CheckedChanged += (sender, e) =>
               { TAB.SelectedTab = (TabPage)((RadioButton)(sender)).Tag; };
            
        }
        bt = (RadioButton) FLP.Controls[FLP.Controls.Count - 1];
        int right = FLP.Controls[FLP.Controls.Count - 2].Right;
        bt.Margin = new Padding(FLP.Width - right - bt.Width - 6, 2, 2, 3);
        FLP.Resize += (sender, e) =>
            {
              bt = (RadioButton)FLP.Controls[FLP.Controls.Count - 1];
              right = FLP.Controls[FLP.Controls.Count - 2].Right;
              bt.Margin = new Padding(FLP.Width - right - bt.Width - 6, 2, 2, 3);
            };
    }

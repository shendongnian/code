        subView = new SubView();
        splitContainer1.Panel2.Controls.Add(subView);
        subView.Dock = DockStyle.Fill;
        subView.Anchor = AnchorStyles.Top & AnchorStyles.Left;
        splitContainer1.Resize += splitContainer1_Resize;

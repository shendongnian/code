    class FilterPanel : FlowLayoutPanel
    {
        TextBox tb_filterBox { get; set; }
        Label st_filterLabel { get; set; }
        public FilterPanel()
        {
            st_filterLabel = new Label();
            st_filterLabel.Text = "Filter:";
            this.Controls.Add(st_filterLabel);
            tb_filterBox = new TextBox();
            this.Controls.Add(tb_filterBox);
            // st_filterLabel.Location = new Point(10, 10);  // not needed for a FLP
            // tb_filterBox.Location = new Point(100, 10);   // use it for a Panel!
            tb_filterBox.TextChanged += tb_filterBox_TextChanged;
        }
        void tb_filterBox_TextChanged(object sender, EventArgs e)
        {
            foreach(Control ctl in this.Controls)
            {
                if (ctl != tb_filterBox && ctl != st_filterLabel)
                    ctl.Visible = ctl.Text.Contains(tb_filterBox.Text);
            }
        }
    }

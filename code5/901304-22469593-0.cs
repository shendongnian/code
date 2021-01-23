    this.month_list.DrawMode = DrawMode.OwnerDrawFixed;
    this.month_list.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
    this.month_list.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
    Font font = new Font("Aerial", 10, FontStyle.Regular);
    bool DisableIndex(int index)
        {
            return index > DateTime.Now.Month - 1;
        }
        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Brush brushToDrawWith = DisableIndex(e.Index) ? Brushes.LightSlateGray : Brushes.Black;
            e.Graphics.DrawString(this.month_list.Items[e.Index].ToString(), font, brushToDrawWith, e.Bounds);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DisableIndex(month_list.SelectedIndex))
            {
                month_list.SelectedIndex = -1;
            }
        }

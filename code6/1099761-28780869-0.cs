    private void dataGridView1_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            // 
            // create and initilize toolTip1
            // 
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            toolTip1.SetToolTip((DataGridView)sender, e.RowIndex.ToString() + " : " + e.ColumnIndex.ToString());
        }
    }
    private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            toolTip1.Dispose();
        }
    }

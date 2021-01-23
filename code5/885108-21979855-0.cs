    public void AddButtontControls()
            {
                tblPanel.SuspendLayout();
                tblPanel.Controls.Clear();           
                tblPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;//.AddColumns;
                tblPanel.ColumnStyles.Clear();
                for (int i = 0; i < tblPanel.ColumnCount; i++)
                {
                    ColumnStyle cs = new ColumnStyle(SizeType.Percent, 100 / tblPanel.ColumnCount);
                    tblPanel.ColumnStyles.Add(cs);
    
                    //Add Button
                    Button a = new Button();
                    a.Text = "Button " + i + 1;                
                    tblPanel.Controls.Add(a);
                }
                tblPanel.ResumeLayout();
            }

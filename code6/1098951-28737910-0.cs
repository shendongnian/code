        private void Form1_Load(object sender, EventArgs e)
        {
            // In case you don't have any initialized column
            UltraGridColumn column = this.ultraGrid1.DisplayLayout.Bands[0].Columns.Add();
            if (!column.IsVisibleInLayout)
            {
                // In order to scroll to particular column, if it is not in view
                this.ultraGrid1.DisplayLayout.ColScrollRegions[0].ScrollColIntoView(column); 
            }
                
            UltraGridColumn visibleColumn = this.ultraGrid1.DisplayLayout.ColScrollRegions[0].VisibleHeaders[0].Header.Column;
        }

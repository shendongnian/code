            dataGridView1.EnableHeadersVisualStyles = false;
            Rectangle headerRect = this.dataGridView1.GetCellDisplayRectangle(dataGridView1.Columns["phone"].Index, -1, true); //get the column header cell
            headerRect.X = headerRect.X + headerRect.Width-2;
            headerRect.Y += 1;
            headerRect.Width = 2*2;
            headerRect.Height -= 2;
            DataGridViewColumn dataGridViewColumn = dataGridView1.Columns["<Column>"];
            Color cl; 
            cl = dataGridView1.ColumnHeadersDefaultCellStyle.BackColor;
            e.Graphics.FillRectangle(new SolidBrush(cl), headerRect);

            if (dataGridView1.CurrentCell.ColumnIndex==0)
            {
                SendKeys.Send("{F2}");//Press key for edit mode
                comboBox1.Visible = true;
                comboBox1.Location = dataGridView1.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true).Location;
                comboBox1.Size = dataGridView1.CurrentCell.Size;
                comboBox1.Focus();//focus on Combobox
            }
        }`

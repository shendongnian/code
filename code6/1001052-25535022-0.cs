    private void dgClasses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv == null)
                return;
            if (dgv.CurrentRow.Selected)
            {
                string selectedval;
                DataGridViewRow row = this.dgClasses.SelectedRows[0];
                selectedval = row.Cells["ID"].Value.ToString();
                XmlReader xmlFile = XmlReader.Create(txtFileLocation.Text, new XmlReaderSettings());
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(xmlFile);
                DataView dvClass = dataSet.Tables["Product"].DefaultView;
                dvClass.RowFilter = "Class=" + "'" + selectedval + "'";
                dgProducts.DataSource = dvClass;
                xmlFile.Close();
            }
        }

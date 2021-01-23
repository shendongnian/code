     public void ChercheStextBox_TextChanged(object sender, EventArgs e)
        {
              //NASSIM LOUCHANI
              BindingSource bs = new BindingSource();
              bs.DataSource = dataGridView3.DataSource;
              bs.Filter = string.Format("CONVERT(" + dataGridView3.Columns[1].DataPropertyName + ", System.String) like '%" + ChercheStextBox.Text.Replace("'", "''") + "%'");
              dataGridView3.DataSource = bs;
         
        }

        private void cmdPaisesFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPaisesFiltro.SelectedItem == null)
                {
                    cmbProvinciasFiltro.DataSource = null;
                    cmbProvinciasFiltro.Items.Clear();
                    return;
                }
                int id = Convert.ToInt32(((DataRowView)cmbPaisesFiltro.SelectedItem).Row["PAI_ID"]);
                DataSet dsDataFromDB = FProvincias.Filtro(id);
                if (dsDataFromDB.Tables[0].Rows.Count == 0)
                {
                   // Selection contains no values in the database, show the label         
                   lblNada.Visible = true;
                   //label
                }
                else
                {
                    // Selection contains values in the database, hide the label
                    lblNada.Visible = false;
                    cmbProvinciasFiltro.DisplayMember = "PROV_DESCRIPCION";
                    cmbProvinciasFiltro.ValueMember = "PROV_ID";
                    cmbProvinciasFiltro.DataSource = dsDataFromDB.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

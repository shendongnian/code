        int selected_colum; // "selected_colum " need be a global var
        
        private void dtg_contatos_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    dtg_contatos.ClearSelection();
                    var hti = dtg_contatos.HitTest(e.X, e.Y);
                    dtg_contatos.Columns[hti.ColumnIndex].Selected = true;
                    selected_colum = hti.ColumnIndex;  // here you set to global var de colum to use at contextmenustrip click
                    dtg_contatos.Columns[selected_colum].Visible = false; // this you will place at contextmenustrip to hide the column
                }
            }
            catch
            {
            }
        }

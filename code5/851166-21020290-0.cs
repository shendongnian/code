    private void dtg_contatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
            {
                string query;
                string name;
                string cod;
    
                for (int i = 0; i < dtg_contatos.ColumnCount; i++)
                {
                    if (i == 0)
                    {
                        cod = dtg_contatos[i, e.RowIndex].Value.ToString();
                    }
                    if (i == 1)
                    {
                        name = dtg_contatos[i, e.RowIndex].Value.ToString();
                    }
                }
                query = "update table set name = '" + name + "' where cod = '" + cod + "';";
            }

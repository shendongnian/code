        public void SavePAC(PlantAreaCode_CreateView CView)
        {
            List<DataGridViewRow> removeRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in CView.dataGridView1.Rows)
            {
                correctSave = false;
                if (row.Cells[col].Value != null)
                {
                    // Creates a model, then populates each field from the cells in the table.
                    PModel = new PlantAreaCode_Model();
                    PModel.AreaCode = Convert.ToString(row.Cells[0].Value);
                    PModel.AreaName = Convert.ToString(row.Cells[1].Value);
                    PModel.Comments = Convert.ToString(row.Cells[2].Value);
                    // Passes the model into the Database.
                    Database_Facade.Operation_Switch(OPWRITE);
                }
                if (correctSave == true) // correctSave is set in the database insert method.
                {
                    removeRows.Add(row);
                }
            }
            foreach (DataGridViewRow rowToRemove in removeRows)
            {
                CView.dataGridView1.Rows.Remove(rowToRemove);
            }
        }

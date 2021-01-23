       public void UpdateTable(Shape sh, System.Data.DataTable dt)
        {
            try
            {
                //Supprimer toutes les lignes existantes
                if (sh.Table.Rows.Count >= 3)
                {
                    int rowCount = sh.Table.Rows.Count;
                    for (int i = 3; i <= rowCount; i++)
                    {
                        sh.Table.Rows[sh.Table.Rows.Count].Delete();
                    }
                    //Vider le contenu de la première ligne
                    for (int j = 1; j < sh.Table.Columns.Count; j++)
                    {
                        sh.Table.Cell(2, j).Shape.TextFrame.TextRange.Text = "";
                    }
                }
                //Parcourir les lignes
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sh.Table.Rows.Add(sh.Table.Rows.Count);
                    //Parcourir les colonnes
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sh.Table.Cell(i + 2, j + 1).Shape.TextFrame.TextRange.Text = dt.Rows[i][j].ToString();
                    }
                }
                sh.Table.Rows[sh.Table.Rows.Count].Delete();
                
                sh.Width = sh.Width + 1;
                sh.Width = sh.Width - 1;
                Marshal.ReleaseComObject(sh);
            }
            catch (Exception exp)
            {
                Logger.Error(exp);
            }
        } 

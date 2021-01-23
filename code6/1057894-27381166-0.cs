    SqlConnection con1 = new SqlConnection();
                    con1.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|\GestStock.mdf;Integrated Security=True;User Instance=True";
                    
                    string insertcmd = "INSERT INTO [Article] (CodeArticle,LibelleFr,LibelleAr,IdCategorie,InfomationsDetaille,Quantite,StockActuel,StockMinimum,PrixAchat,DateAchat,NumeroFacture)" +
                         "VALUES(@CodeArticle1,@LibelleFr1,@LibelleAr1,@IdCategorie1 ,@InfomationsDetaille1,@Quantite1,@StockActuel1,@StockMinimum1,@PrixAchat1,@DateAchat1,@NumeroFacture1)";
                    SqlCommand cmd=new SqlCommand(insertcmd,con1);
                    con1.Open();
                    for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                    {
                        cmd.Parameters.AddWithValue("@CodeArticle1", dataGridView2.Rows[i].Cells["codeArticleDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@LibelleFr1",dataGridView2.Rows[i].Cells["libelleFrDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@LibelleAr1",dataGridView2.Rows[i].Cells["libelleArDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@IdCategorie1",dataGridView2.Rows[i].Cells["idCategorieDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@InfomationsDetaille1",dataGridView2.Rows[i].Cells["InfomationsDetailleDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@Quantite1",dataGridView2.Rows[i].Cells["QuantiteDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@StockActuel1",dataGridView2.Rows[i].Cells["StockActuelDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@StockMinimum1",dataGridView2.Rows[i].Cells["StockMinimumDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@PrixAchat1",dataGridView2.Rows[i].Cells["PrixAchatDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@DateAchat1",dataGridView2.Rows[i].Cells["DateAchatDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@NumeroFacture1",dataGridView2.Rows[i].Cells["NumeroFactureDataGridViewTextBoxColumn"].Value);
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    MessageBox.Show("données enregistrés");
                    con1.Close();

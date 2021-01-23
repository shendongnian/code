    try
                {
                    cBuild = new OleDbCommandBuilder(adapter);
                    adapter.Update(dt);
                }
                catch (Exception)
                {
                    MessageBox.Show("DO NOT DUPLICATE STUDENTID");
                }

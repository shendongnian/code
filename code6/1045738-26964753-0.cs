    System.Data.DataSet dsTemp2 = new System.Data.DataSet();
    if (dsTemp2.Tables[0].Rows.Count <= 0)
                        MessageBox.Show("Records not found");
                    else
                    {
                        foreach (DataRow dRow in dsTemp2.Tables[0].Rows)
                        {
                            yourtextbox1.Text = dsTemp2.Tables[0].Rows[0][4].ToString();
                            yourtextbox2.Text = dsTemp2.Tables[0].Rows[0][5].ToString();
                            yourtextbox3.Text = dsTemp2.Tables[0].Rows[0][7].ToString();
                        }
                    }

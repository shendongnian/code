     if (reader.Read())
                {
                    var resultpass = reader["password"];
                    int userid = Convert.ToInt32(reader["ID"]);
                    if (resultpass != DBNull.Value)
                    {
    
                        string aad = newpassword.Text;
    
                        if (newpassword.Text == newpasswordagain.Text)
                        {
    
    
    
                            String baskasq = "UPDATE user SET password=@newpas WHERE ID=@userid";
                            try
                            {
                                SqlCommand komut = new SqlCommand(baskasq, connection);
                                komut.Parameters.AddWithValue("@newpas", aad);
                                komut.Parameters.AddWithValue("@userid", userid);
                                komut.ExecuteNonQuery();
                            }
                            // hata kodu 1: 
                            // update fonksiyonu çalışmıyor
                            catch (Exception ee)
                            {
                                System.Windows.Forms.MessageBox.Show("Hata oluştu ! HATA KODU : 1");
                                passwordnow.Text = "";
                                newpassword.Text = "";
                                newpasswordagain.Text = "";
                                passwordnow.Focus();
                                connection.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("please check whether you entered passwords the same or not.");
                        }
    
    
    
                    }
                    else
                    {
                        MessageBox.Show("please enter password correctly.");
                        connection.Close();
                    }
                }

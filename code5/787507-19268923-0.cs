       SqlCommand cmd4 = new SqlCommand("update TrackingFaculty_det " + 
                                        "SET EmailsentDate=@Email WHERE FID=@FID", cn1);
       cn1.Open();
       cmd4.Parameters.Add("@Email", SqlDbType.DateTime, 8);
       cmd4.Parameters.Add("@FID",SqlDbType.VarChar,10);
       for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
       {
           .....
           if (Ckbox.Checked == true)
           {
              ....
              cmd4.Parameters["@Email"].Value = sdt;
              cmd4.Parameters["@FID"].Value = FID1;
              cmd4.ExecuteNonQuery();
           }
       }
       cn1.Close();

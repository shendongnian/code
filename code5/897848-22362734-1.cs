    try
    {
        cnn.Open();
        var cmdd = "insert into poroje (Pname,Pmozu,Ppayan,StartDate,EndTime,makan,tozih) values(@Pname,@Pmozu,@Ppayan,@StartDate,@EndTime,@makan,@tozih)";
        using (SqlConnection cnn = new SqlConnection(conn))
        {
            using (SqlCommand cmd = new SqlCommand(cmdd, cnn))
            {
                if (aksporoje.HasFile)
                {
                    if (CheckFileType(aksporoje.FileName))
                    {
                       PersianCalendar Pe = new PersianCalendar();
                       string s = Pe.GetYear(System.DateTime.Now).ToString();
                       if (Directory.Exists("~/poroje/"+s))
                       {
                           Directory.CreateDirectory(Server.MapPath("~/poroje/" + s+pushePoroje(System.DateTime.Today)));
                           string filePath = "~/poroje/" + s + "/" + pushePoroje(System.DateTime.Today) + "/" + aksporoje.FileName;
                           aksporoje.SaveAs(MapPath(filePath));
                           cmd.Parameters.AddWithValue("@aks","poroje/"+ s + "/" + pushePoroje(System.DateTime.Today) + "/" + aksporoje.FileName);
                       }
                       else {
                           Directory.CreateDirectory(Server.MapPath("~/poroje/"+s));
                           Directory.CreateDirectory(Server.MapPath("~/poroje/"+s+ pushePoroje(System.DateTime.Today)));
                           string filePath = "~/poroje/" + s + "/" + pushePoroje(System.DateTime.Today) + "/" + aksporoje.FileName;
                           aksporoje.SaveAs(MapPath(filePath));
                           cmd.Parameters.AddWithValue("@aks", "poroje/" + s + "/" + pushePoroje(System.DateTime.Today) + "/" + aksporoje.FileName);
                       }
                   }
                } 
                cmd.Parameters.AddWithValue("@Pname", txtnam.Text);
                cmd.Parameters.AddWithValue("@Pmozu", txtmozu.Text);
                cmd.Parameters.AddWithValue("@Ppayan",false);
                cmd.Parameters.AddWithValue("@StartDate",PersianDateTextBox1.Text);
                cmd.Parameters.AddWithValue("@EndTime",null);
                cmd.Parameters.AddWithValue("@makan", txtmakan.Text);
                cmd.Parameters.AddWithValue("@tozih", txttozih.Text);
                cmd.ExecuteNonQuery();
                }
                catch (SqlException)
                {
                    lblpeygham.Visible = true;
                    lblpeygham.Text = "error";
                }
                finally
                {
                    cnn.Close();
                    lblpeygham.Visible = true;
                    lblpeygham.Text = "data inserted";
                }

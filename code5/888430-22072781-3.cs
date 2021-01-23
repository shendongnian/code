     protected void Page_Load(object sender, EventArgs e)
    {
        using (SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=RnD;Persist Security Info=True;)) //change as needed
        {
            using (StreamReader sr = new StreamReader(Request.InputStream, Encoding.UTF8))
            {
                Response.ContentType = "text/plain";
                string UserID = Request.Form["EmpID"];
                //SQL CODE
                string c = "sql Code";
                try
                {
                    SqlCommand cmd = new SqlCommand(c, cn);
                    cn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
                    while (rdr.Read())
                    {
                        Dictionary<string, object> d = new Dictionary<string, object>(rdr.FieldCount);
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            d[rdr.GetName(i)] = rdr.GetValue(i);
                        }
                        list.Add(d);
                    }
                    JavaScriptSerializer j = new JavaScriptSerializer();
                    Response.Write("{\"JSON\":");
                    Response.Write(j.Serialize(list.ToArray()));
                    Response.Write("}");
                }
                catch (Exception ex)
                {
                    Response.TrySkipIisCustomErrors = true;
                    Response.StatusCode = 500;
                    Response.Write("Error occurred. Query=" + c + "\n");
                    Response.Write(ex.ToString());
                }
                Response.End();
            }
        }
    }

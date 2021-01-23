    foreach (DataRow dr in dt.Rows)
                {
    
                    PID2 = dr["id"].ToString();
                    if (PID.ToString() != PID2 )
                    {
    
                        var field = "<a href='" + Page.ResolveUrl("~/PageView.aspx?Email=" +                     dr["id"].ToString()) + "'>" + (dr["First_Name"] + "").ToString() + "</a>";
    
                        Session["SurnameView_" + PID2 ] = dr["Surname"];
                        string check1 = dr["Surname"].ToString();
                        Session["idView_" + PID2] = dr["id"];
                        string check2 = dr["id"].ToString();
                        Session["EmailView_" + PID2] = dr["Email_Account"];
                        string check3 = dr["Email_Account"].ToString();
    
    
    
                        Response.Write(field);
    
                        HttpContext context = HttpContext.Current;
    
                        Response.Write("<br/>");
                    }
                }

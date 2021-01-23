    DataSet ds = ViewState["Data"] as DataSet;
                    DataView sortedView = (ds.Tables[0]).DefaultView;
                    //DataTable dt = ViewState["Data"].ToString();
    
                    //Create a dummy GridView
                    GridView GridView1 = new GridView();
                    GridView1.AllowPaging = false;
                    GridView1.DataSource = sortedView;
                    GridView1.DataBind();
                    GridView1.Caption = "ABCD"; //// allows you to give caption to excel sheet
                    Response.Clear();
                    Response.Buffer = true;
                    Response.AddHeader("content-disposition", "attachment;filename=RM.xls");
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.ms-excel";
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
    
                    for (int i = 0; i < GridView1.Rows.Count; i++)
                    {
                        //Apply text style to each Row
                        GridView1.Rows[i].Attributes.Add("class", "textmode");
                    }
                    GridView1.Caption = "RM Master";
                    GridView1.RenderControl(hw);
                    //style to format numbers to string
                    string style = @"<style> .textmode { mso-number-format:\@; } </style>";
                    Response.Write(style);
                    Response.Output.Write(sw.ToString());
                    Response.Flush();
                    Response.End();

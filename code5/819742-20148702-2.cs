          string attachment = "attachment; filename=xxxx" + DateTime.Now + ".xls";
                    Response.ClearContent();
                    Response.AddHeader("content-disposition", attachment);
                    Response.ContentType = "application/ms-excel";
        			datatable dt = new datatable();
        		      // dt =  Your query to get result 
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                        {                 
                            GridView1.DataSource = dt;//Bind your gridview 
                            GridView1.DataBind();
                            dg.RenderControl(htw);
                            Response.Write(sw.ToString());
                            Response.End();
                        }
                    }

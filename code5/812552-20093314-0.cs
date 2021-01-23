                string path = System.IO.Path.GetTempPath() + System.DateTime.Now.Ticks + ".xls";
                GridView grdTemp = new GridView();
                grdTemp.DataSource = dt;
                grdTemp.Caption = "Products<br>  " + DateTime.Now;
                grdTemp.DataBind();
                using (StreamWriter sw = new StreamWriter(path))
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        grdTemp.RenderControl(hw);
                    }
                }
                string save_path = path;
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", System.DateTime.Now.Ticks + ".xls"));
                Response.ContentType = "application/excel";
                Response.WriteFile(save_path);
                Response.End();
                System.IO.File.Delete(save_path);

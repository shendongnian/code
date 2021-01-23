        void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
                {
                    if (e.Row.RowType == DataControlRowType.DataRow)
                    {
                                HyperLink Srl = (HyperLink)e.Row.FindControl("Srl");     
                
                                foreach (string color in colorList)
                                {
                
                
                string str = (string)DataBinder.Eval(e.Row.DataItem, "File");
                //then you can check
                if (!String.IsNullorEmpty(str ))
                {
                                            Srl.Visible = true;
                                        }
                                    }
                                }
     }
    }

    public DataSet GetAllProjectStandardIcons2()
            {
                var images = (from p in dbModel.tbl_STANDARDPROJECTICONS
                              select new ProjectDetails1
                              {
                                  id = p.id,
                                  ProjectIcons = (Byte[])(p.ProjectIcons)
    
                              }).ToList();
    
               
                DataTable dt = new DataTable();
                if (images.Count > 0)
                {
                    Byte[] ProjectIcons;
                    DataColumn dc = new DataColumn("id");
                    DataColumn dc1 = new DataColumn("ProjectIcons");
                    dt.Columns.Add(dc);
                    dt.Columns.Add(dc1);
                    for (var i = 0; i < images.Count(); i++)
                    {
    
                        DataRow row = dt.NewRow();
                        row["id"] = images[i].id;
                        row["ProjectIcons"] = Convert.ToBase64String(images[i].ProjectIcons);//convert here byte array to base64
                        dt.Rows.Add(row);
                    }
                }
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                return ds;
    
            }

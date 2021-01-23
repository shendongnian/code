    protected void grdGalleryData_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var personId = Convert.ToInt32((e.Row.DataItem as DataRowView)["Id"]);
                    var imageListView = e.Row.FindControl("lvImages") as ListView;
    
                    //Just for demo purpose. Get only required image data based on the parent table id  in actual code.
                    if (data == null)
                    {
                        data = GetData();
                    }
                    var resultRows = data.Tables["PersonImages"].AsEnumerable().Where(img => img.Field<int>("Person_Id") == personId); 
                    DataTable dtImages = new DataTable();
                    if (resultRows != null && resultRows.Count()>0)
                        dtImages = resultRows.CopyToDataTable();
                    imageListView.DataSource = dtImages;
                    imageListView.DataBind();
                }
            }

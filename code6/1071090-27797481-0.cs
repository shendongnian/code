    void BindGrid()
    {
     using (SqlConnection con = new SqlConnection(conString))
                {
                    using (SqlDataAdapter personAdapter = new SqlDataAdapter("SELECT * FROM PersonTable", con))
                    using (SqlDataAdapter personImagesAdapter = new SqlDataAdapter("SELECT * FROM PersonImages", con))
                    {
    
                        DataSet dataSet = new DataSet("PersonAndImagesDataSet");
                        personAdapter.Fill(dataSet, "PersonTable");
                        personImagesAdapter.Fill(dataSet, "PersonImages");
    
                        DataRelation personWithImages = dataSet.Relations.Add("PersonAndImages", dataSet.Tables["PersonTable"].Columns["Id"],
                                                                                                 dataSet.Tables["PersonImages"].Columns["Person_Id"]);
                        if (grdGalleryData.DataSource == null)
                        {
                            grdGalleryData.DataSource = dataSet.Tables["PersonTable"];
                            grdGalleryData.DataBind();
                        }
    
    
                    }
                }
    }

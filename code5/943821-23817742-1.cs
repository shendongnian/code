    		protected void Page_Load(object sender, EventArgs e)
    		{
                if (!IsPostBack)
                {
            
                    //Connect
                    string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jeroen\Documents\Visual Studio 2010\Projects\producten\producten\App_Data\Bimsports.accdb;Persist Security Info=True";
                    OleDbConnection conn = new OleDbConnection(connectionstring);
    
    
                    //Execute
                    string sql = "SELECT Artikelnummer, Omschrijving FROM Artikel";
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    //Read
                    try
                    {
                        conn.Open();
                        OleDbDataReader reader = cmd.ExecuteReader();
                        ddlartikel.DataSource = reader;
                        ddlartikel.DataValueField = "artikelnummer";
                        ddlartikel.DataTextField = "omschrijving";
                        ddlartikel.DataBind();
                    }
                        finally{conn.Close();}
                    FetchPicture();
    	 	    }
            }
    
            protected void ddlartikel_SelectedIndexChanged(object sender, EventArgs e)
            {
                FetchPicture();
            }
            private void FetchPicture()
            {
                if (ddlartikel.SelectedIndex > -1)
                {
                    int artikelnummer = Convert.ToInt32(ddlartikel.SelectedValue);
                    string sUrl = string.Format("~/afbeelding.ashx?artikelnummer={0}", artikelnummer);
                    imgfoto.ImageUrl = sUrl;
                }
            }
    
            protected void btnsave_Click(object sender, EventArgs e)
            {
                if (FileUpload1.HasFile)
                {
                    byte[] MyData = FileUpload1.FileBytes;
    
                    int artikelnummer = Convert.ToInt32(ddlartikel.SelectedValue);
                    CBlob.SavePicture(artikelnummer, MyData);
                }
            }
    
      
        }
    }

                MastersClient objIndent = new MastersClient();
                DataSet ds = objIndent.GetIndent(hidIndentID.Value);
                DataRow[] drIndentID = ds.Tables[0].Select("IndentID =" + hidIndentID.Value);
                if (drIndentID.Length > 0)
                { 
                  rptCategories.DataSource=ds.Tables[0];
                }
    

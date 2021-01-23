    private void Page_Load(object sender, System.EventArgs e)
    {
    
         if(!Page.isPostback)
         {
             myDataSet = Session["myDataset"] as DataSet;
    
             if( myDataSet != null && myDataSet.Tables[0].Rows.Count > 0 )
             {
                myDBType = myDataSet.Tables[0].Rows[0]["dbType"].ToString();
             }
             else
             {
                 myDBType = Connection.GetDBType(someid);
             }
         
             string displayStatus = "Value1: " + myID.Tables[0].Rows[0][0].ToString() +
                 " Value2: " + myDataSet.Tables[0].Rows[0][1].ToString() +
                 " Value3: " + myDataSet.Tables[0].Rows[0][5].ToString() + " DBType: " + myDBType;
        
             string resultScript;
             resultScript = "<script>parent.top.setStatusText('" + displayStatus + "');     </script>";
             Page.RegisterClientScriptBlock("resultClientBlock",resultScript);
         
             SwitchDBType(intmid, permTempCheck, myDbType);
        }
    }

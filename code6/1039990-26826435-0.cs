     string name = (string)(Session["LoginUserName"]);
       if(FileUpload3.FileName == null ){
       
       lblmessage.Text = "Choose the file First then click import ";
       string display = "             Choose the file First then click import                   ";
       ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
       }
       else 
       {
       
       
           string path = Path.Combine(Server.MapPath("~/ImportDocument"), Guid.NewGuid().ToString() + name + Path.GetExtension(FileUpload3.PostedFile.FileName));
       FileUpload3.PostedFile.SaveAs(path);
       OleDbConnection dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + "; Extended Properties = \"Excel 8.0;HDR=Yes;IMEX=2\" ");
        dbConnection.Open();
        try
       {       
           // Get the name of the first worksheet:
           DataTable dbSchema = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
           if (dbSchema == null || dbSchema.Rows.Count < 1)
           {
               throw new Exception("Error: Could not determine the name of the first worksheet.");
           }
           string firstSheetName = dbSchema.Rows[0]["TABLE_NAME"].ToString();
           // Now we have the table name; proceed as before:
           OleDbCommand dbCommand = new OleDbCommand("Select [IdOftable], [Time],[InstrumentLeftHand],[LeftSwitch],[LeftKnob],[ForceFeedbackLeftHand],[CumTimeLeftForceOverThreshold],[CumTimeLeftForceOver2xThreshold],[TranslationLeft_x],[TranslationLeft_y],[TranslationLeft_z],[quatLeft_x],[quatLeft_y],[quatLeft_z],[quatLeft_w],[InstrumentRightHand],[RightSwitch],[RightKnob],[ForceFeedbackRightHand],[CumTimeRightForceOverThreshold],[CumTimeRightForceOver2xThreshold],[TranslationRight_x],[TranslationRight_y],[TranslationRight_z],[quatRight_x],[quatRight_y],[quatRight_z],[quatRight_w],[BloodEmittedFrame],[BloodCurrentFrame],[TotalBloodEmitted],[TotalWhiteFibreCut],[TotalRedFibreCut],[Volume0_Brain],[Volume1_Tumor],[Volume2_Tumor] from [" + firstSheetName + "]", dbConnection);
           OleDbDataReader dbReader = dbCommand.ExecuteReader();
          
           using (SqlBulkCopy bulkCopy = new SqlBulkCopy(conn))
           {
              
               bulkCopy.DestinationTableName = "MyExcel";
               try
               {
                   conn.Open();
                   bulkCopy.BulkCopyTimeout = 400;
                   bulkCopy.WriteToServer(dbReader);
                   bulkCopy.BatchSize = 16000;
                   conn.Close();
               }
                   
               catch (Exception ex)
               {
                   Response.Write(ex.ToString());
               }
               finally
               {
                   bulkCopy.Close();
                   dbReader.Close();
                   //lblmessage.Text = " data successfully imported  ";
               //    Response.Write(@"<script language=""javascript"">alert('Details saved successfully')</script>");
                   string display = "             Data Duccessfully Imported  Now Click On Calculate the result to calculate your results taking in your account The calculation will take a while , please wait   ";
                   ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + display + "');", true);
               }
           
              
           }
       }
       finally
       {
           dbConnection.Close();
       }
    }

    //(Your code...)
      OracleDataReader myReader = default(OracleDataReader);
      try
      {   //Here the magic
          myReader = myCMD.ExecuteReader();
      }
      catch (Exception myex)
      {
          Label1.Text = " " + myex.Message;
      }
     
     int x = 0;
     int count = 0;
     
     string actualValue = string.Empty;
     /*This data type is from .Net. Like: "System.DateTime" - "System.String" - etc*/
     string actualDataType = string.Empty; 
     while(myReader.Read())
     {
      //Here you can use GetValue and GetType
         actualValue = myReader.GetValue(count).ToString();
         actualDataType = myReader.GetType(count).ToString();
         count++;
     }
    

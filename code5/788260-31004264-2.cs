    DataTable excelData = objGetExcelData.DataExcel(objEntities.StrFilePath, ConfigSettings.GetAppConfigValue("select * from sheet1"));
    
    StringBuilder strInput = new StringBuilder();
    DataView view = new DataView(excelData); 
    DataTable distinctValues = view.ToTable(true, "GROUP_NAME"); 
    if (distinctValues.Rows.Count > 0)
    {
          for (int i = 0; i < distinctValues.Rows.Count; i++)
          {
               strGroupName = Convert.ToString(distinctValues.Rows[i]["GROUP_NAME"]);
               foreach (DataRow item in excelData.Select("GROUP_NAME = '" + strGroupName + "'"))
               {
                   strInput.Append(Convert.ToString(item[0]));
                   strInput.Append("~");
                   strInput.Append(Convert.ToString(item[1]));
                   strInput.Append(",");
                   strDasID = Convert.ToString(item[0]);
                }
          }
    }

    public int ValidationExcelBal(string excelPath, string objectReferenceExcelPath)
    {
        using (DataTable dtPointList = new DataTable())
        {
            using (DataTable dtAlarm = new DataTable())
            {
                using (DataTable dtObjectReference = new DataTable())
                {
                    try
                    {
                        int objectReferenceColNum = -1;
                        int objectReferenceAlarmColNum = -1;
    
    
                        objGGTAutoBindingToolDal.YomitoriExcelToDataTable(excelPath, ref dtPointList, ref dtAlarm);
                        objGGTAutoBindingToolDal.ObjectReferenceExcelToData(objectReferenceExcelPath, ref dtObjectReference);
    
                        #region code to find object reference column number in excel sheet and Alarm sheet
    
    
                        for (int i = 0; i < dtPointList.Columns.Count; i++)
                        {
                            for (int k = 0; k < dtPointList.Rows.Count; k++)
                            {
                                if (k < 4)
                                {
                                    string name = dtPointList.Rows[k][i].ToString().Replace("\n", "").Replace(" ", "");
                                    if (name == "ObjectReference")
                                    {
                                        objectReferenceColNum = i;
                                        break;
                                    }
                                }
                            }
                        }
    
                        //code to find colomn number of object reference field in Alarm sheet
                        for (int j = 0; j < dtAlarm.Columns.Count; j++)
                        {
                            string name = dtAlarm.Rows[0][j].ToString();
                            if (name.Equals("Object Reference"))
                            {
                                objectReferenceAlarmColNum = j;
                                break;
                            }
                        }
    
                        #endregion
    
                        if (objectReferenceColNum == -1 || objectReferenceAlarmColNum == -1)
                        {
                            return 1;
                        }
    
                        //if (Convert.ToString(dtObjectReference.Columns[0]).Contains("Bldg Name") || Convert.ToString(dtObjectReference.Columns[1]).Contains("Graphics Name") || Convert.ToString(dtObjectReference.Columns[2]).Contains("Controller Object Reference"))
                        //{
    
                        //    return 2;
                        //}
    
                        return 3;
                    }
                    catch (Exception)
                    {
                        dtPointList.Dispose();
                        dtAlarm.Dispose();
                        dtObjectReference.Dispose();
                        throw;
                    }
                }
            }
    
    
    
        }
    }

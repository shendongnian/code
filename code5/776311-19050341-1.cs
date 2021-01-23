    public DataTable CallModule()
        {
            try{
            Microsoft.Office.Interop.Access.Application oAccess = new Microsoft.Office.Interop.Access.Application();
            oAccess.Visible = false;
            oAccess.OpenCurrentDatabase(DataBase, false);
            dao.Recordset oRecordSet = oAccess.Run("fReturnRecordset");
            oRecordSet.OpenRecordset();
           //------------------------------------
            DataTable dt = new DataTable();
            dt.Columns.Add("OriginalName");
            dt.Columns.Add("ModifiedName");
            while (!oRecordSet.EOF )
            {
                DataRow dr = dt.NewRow();
                dr["OriginalName"] = Convert.ToString(oRecordSet.Fields[0].Value);
                dr["ModifiedName"] = Convert.ToString(oRecordSet.Fields[1].Value);
                dt.Rows.Add(dr);
                oRecordSet.MoveNext();
            }
  
            oRecordSet.Close();
            oAccess.DoCmd.Quit(AcQuitOption.acQuitSaveNone);
            
            oAccess = null;
            return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

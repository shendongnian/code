            int _returnVal = -1;
            try
            {
                DbParam[] param = new DbParam[2]{
                                       new DbParam("@SKUTypeCode", SKUTypeCode, SqlDbType.VarChar), 
                                       new DbParam("@SearchString", SellingSKUIds, SqlDbType.VarChar)
                                    };
                _returnVal = Db.Update("usp_DeleteSKUMappingItems", param);
            }
            catch (Exception ex)
            {
                _returnVal = -1;
                 WINIT.ErrorLog.ErrorLogger.GetInstance().Log(ex, WINIT.ErrorLog.LogSeverity.Error);
            }
            return _returnVal;
        }

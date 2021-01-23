    using Excel;
    
            try
            {
                FileStream stream = File.Open(strFilePath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = null;
                if (extension.Trim() == ".xls")
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (extension.Trim() == ".xlsx")
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                excelReader.Close();
                mResult = new ResponseModel<DataTable>()
                {
                    Status = ResponseStatus.Success,
                    Message = ResponseMessages.OK,
                    Result = result.Tables[0]
                };
            }
            catch (Exception err)
            {
                mResult.Message = err.Message;
            }

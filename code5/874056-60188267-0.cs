    public void ExcelDataAssign(List<string> ColumnwiseData, int length, DateTime ReportDate, List<string> AmountList, List<string> PeriodDateList, int CellId)
        {
            int PeriodColIndex = 6, Desc1ColIndex = 14, Desc2ColIndex = 11, Desc3ColIndex = 9, PeriodDateColIndex = 7;
            int PeriodRowIndex = 3, Desc1RowIndex = 1, Desc2RowIndex = 1, Desc3RowIndex = 1, PeriodDateRowIndex = 3;
    
    
            string cellName = ColumnwiseData[length];
            string CapitiveName = ColumnwiseData[2 * length];
            string DomicileName = ColumnwiseData[3 * length];
    
    
            string file = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Excel\OutputTemplate.xlsx";
            string fileName = file.Replace("bin", "").Replace("Debug", "");
            var workbook = new XLWorkbook(fileName);
            var ws1 = workbook.Worksheet(1);
    
            ws1.Cell(1, 2).Value = DomicileName;
            ws1.Cell(2, 2).Value = CapitiveName;
            ws1.Cell(3, 2).Value = cellName;
            ws1.Cell(4, 2).Value = ReportDate;
    
            int amntIncr = 0;
            while (AmountList.Count > amntIncr)
            {
                ws1.Cell(PeriodColIndex, PeriodRowIndex).Value = "Period";
                ws1.Cell(Desc1ColIndex, Desc1RowIndex + 2).Value = AmountList[amntIncr];
                ws1.Cell(Desc2ColIndex, Desc2RowIndex + 2).Value = (AmountList[amntIncr + 1]);
                ws1.Cell(Desc3ColIndex, Desc3RowIndex + 2).Value = (AmountList[amntIncr + 2]);
                PeriodRowIndex++;
                Desc1RowIndex++;
                Desc2RowIndex++;
                Desc3RowIndex++;
                amntIncr = amntIncr + 3;
    
            }
            int periodDateIncr = 0;
            while (PeriodDateList.Count > periodDateIncr)
            {
                ws1.Cell(PeriodDateColIndex, PeriodDateRowIndex).Value = PeriodDateList[periodDateIncr];
                PeriodDateRowIndex++;
                periodDateIncr = periodDateIncr + 3;
            }
    
            var ws2 = workbook.Worksheet(2);
            ws2.Cell(1, 2).Value = DomicileName;
            ws2.Cell(2, 2).Value = CapitiveName;
            ws2.Cell(3, 2).Value = cellName;
            ws2.Cell(4, 2).Value = ReportDate;
    
    
            SqlParameter paramCellId = new SqlParameter("@CellId", CellId);
            SqlParameter paramReportDate = new SqlParameter("@ReportDate", ReportDate);
            DataTable dt = new DataTable();
            var data = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Usp_inputResult", paramCellId, paramReportDate).Tables[0];
    
    
            List<string> lstClmwiseData = new List<string>();
    
            foreach (DataRow r in data.Rows)
            {
                foreach (DataColumn c in data.Columns)
                {
                    lstClmwiseData.Add(r[c].ToString());
                }
            }
    
            int snoColIndex = 6, GLCodeColIndex = 6, DescriptioColIndex = 6, movementDebitColIndex = 6, movementCreditColIndex = 6, ClosingdebitcolIndex = 6, ClosingCreditColIndex = 6;
            int snoRowIndex = 1, GLCodRowIndex = 2, DescriptioRowIndex = 3, movementDebitRowIndex = 4, movementCreditRowIndex = 5, ClosingdebitRowIndex = 6, ClosingCreditRowIndex = 7;
            int secondSheet = 0;
            int SnoIncrement = 1;
            while (lstClmwiseData.Count > secondSheet)
            {
                ws2.Cell(snoColIndex, snoRowIndex).Value = SnoIncrement;
                ws2.Cell(GLCodeColIndex, GLCodRowIndex).Value = lstClmwiseData[secondSheet];
                ws2.Cell(DescriptioColIndex, DescriptioRowIndex).Value = lstClmwiseData[secondSheet + 1];
                ws2.Cell(movementDebitColIndex, movementDebitRowIndex).Value = lstClmwiseData[secondSheet + 2];
                ws2.Cell(movementCreditColIndex, movementCreditRowIndex).Value = lstClmwiseData[secondSheet + 3];
                ws2.Cell(ClosingdebitcolIndex, ClosingdebitRowIndex).Value = lstClmwiseData[secondSheet + 4];
                ws2.Cell(ClosingCreditColIndex, ClosingCreditRowIndex).Value = lstClmwiseData[secondSheet + 5];
                snoColIndex++;
                GLCodeColIndex++;
                DescriptioColIndex++;
                movementDebitColIndex++;
                movementCreditColIndex++;
                ClosingdebitcolIndex++;
                ClosingCreditColIndex++;
                SnoIncrement++;
                secondSheet = secondSheet + 6;
    
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\ReportUtitlity";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string FileName = workbook.Author + "_" + "Report_"+CellId+ "CellId" +"_" + $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}";
            workbook.SaveAs(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\ReportUtitlity\" + FileName + ".xlsx");
        }

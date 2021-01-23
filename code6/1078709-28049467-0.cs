    public void CreateExcelFirstTemplate()
        {   
           var fileName = "ExcellData.xlsx";
           using (var package = new OfficeOpenXml.ExcelPackage(fileName))
           {
              var worksheet = package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Attempts");
              worksheet = package.Workbook.Worksheets.Add("Assessment Attempts");
              worksheet.Row(1).Height = 20;
        
              worksheet.TabColor = Color.Gold;
              worksheet.DefaultRowHeight = 12;
              worksheet.Row(1).Height = 20;
        
              worksheet.Cells[1, 1].Value = "Employee Number";
              worksheet.Cells[1, 2].Value = "Course Code";
        
              var cells = worksheet.Cells["A1:J1"];
              var rowCounter = 2;
              foreach (var v in userAssessmentsData)
              {
                worksheet.Cells[rowCounter, 1].Value = v.CompanyNumber;
                worksheet.Cells[rowCounter, 2].Value = v.CourseCode;
        
                rowCounter++;
              }
              worksheet.Column(1).AutoFit();
              worksheet.Column(2).AutoFit();
        
        
              package.Workbook.Properties.Title = "Attempts";
              this.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
              this.Response.AddHeader(
                        "content-disposition",
                        string.Format("attachment;  filename={0}", "ExcellData.xlsx"));
              this.Response.BinaryWrite(pck.GetAsByteArray());
          }
    }

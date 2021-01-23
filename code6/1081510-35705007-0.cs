                    var workbook = new XSSFWorkbook();
                var members = (obj as IEnumerable<MemberListViewModel>).ToDataSourceResult(request).Data;
                var sheet = workbook.CreateSheet(TempData["List"].ToString());
                var headerRow = sheet.CreateRow(0);
                headerRow.CreateCell(0).SetCellValue("Name");
                headerRow.CreateCell(1).SetCellValue("Degrees");
                headerRow.CreateCell(2).SetCellValue("Rank");
                headerRow.CreateCell(3).SetCellValue("Endowed Professorship");
                headerRow.CreateCell(4).SetCellValue("Department");
                headerRow.CreateCell(5).SetCellValue("Program");
                var font = workbook.CreateFont();
                font.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;
                XSSFCellStyle style = (XSSFCellStyle)workbook.CreateCellStyle();
                style.SetFont(font);
                style.FillPattern = NPOI.SS.UserModel.FillPattern.SolidForeground;
                style.FillForegroundColor = IndexedColors.Grey25Percent.Index;
                style.IsLocked = false;
                style.WrapText = true;
                for (int i = 0; i < 6; i++)
                {
                    var colStyle = sheet.GetColumnStyle(i);
                    colStyle.WrapText = !colStyle.WrapText;
                    sheet.SetDefaultColumnStyle(i, colStyle);
                    var cell = headerRow.Cells[i];
                    cell.CellStyle = style;
                }
                headerRow.RowStyle = style;
                sheet.SetColumnWidth(0, 30 * 256);
                sheet.SetColumnWidth(1, 20 * 256);
                sheet.SetColumnWidth(2, 20 * 256);
                sheet.SetColumnWidth(3, 50 * 256);
                sheet.SetColumnWidth(4, 30 * 256);
                sheet.SetColumnWidth(5, 50 * 256);
                int rowNumber = 1;
                style = (XSSFCellStyle)workbook.CreateCellStyle();
                style.IsLocked = false;
                style.WrapText = true;
                foreach (MemberListViewModel member in members)
                {
                    var row = sheet.CreateRow(rowNumber++);
                    row.CreateCell(0).SetCellValue(member.FullName);
                    row.CreateCell(1).SetCellValue(member.degrees);
                    row.CreateCell(2).SetCellValue(member.rank);
                    row.CreateCell(3).SetCellValue(member.endowed_professorship);
                    row.CreateCell(4).SetCellValue(member.department);
                    row.CreateCell(5).SetCellValue(member.program);
                }
                //var colStyle = sheet.GetColumnStyle(3);
                //colStyle.WrapText = !colStyle.WrapText;
                //sheet.SetDefaultColumnStyle(3, colStyle);
                workbook.Write(output);
                var fileName = String.Format(
                                "{0} {2} - {1}.xlsx",
                                DateTime.Now.ToString("yyyyMMdd-HHmmss"),
                                Utilities.getUsername(Utilities.GetCurrentUser()), TempData["List"]).Replace(":", "");
                var file = File(output.ToArray(), Utilities.ExcelFileContentType, fileName);
                var context = System.Web.HttpContext.Current;
                context.Response.Clear();
                context.Response.ClearContent();
                context.Response.ClearHeaders();
                context.Response.AddHeader("content-disposition", String.Format("inline;filename=\'{0}\'", fileName));
                context.Response.ContentEncoding = System.Text.Encoding.UTF8;
                context.Response.ContentType = file.ContentType;
                context.Response.AddHeader("content-length", file.FileContents.Length.ToString());
                context.Response.BinaryWrite(buffer: file.FileContents.ToArray());
                context.Response.Flush();
                context.Response.End();
                output.Dispose();

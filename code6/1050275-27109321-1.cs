    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MVCImportExcel.Models;
    using System.Data;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    using System.IO;
    namespace MVCImportExcel.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
            public ActionResult Index()
            {
                var model = new MyViewModel();
                return View(model);
            }
            [HttpPost]
            public ActionResult Index(MyViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                DataTable dt = GetDataTableFromSpreadsheet(model.MyExcelFile.InputStream,false);
                string strContent = "<p>Thanks for uploading the file</p>" + ConvertDataTableToHTMLTable(dt);
                model.MSExcelTable = strContent;
                return View(model);
            }
            public static DataTable GetDataTableFromSpreadsheet(Stream MyExcelStream, bool ReadOnly)
            {
                DataTable dt = new DataTable();
                using (SpreadsheetDocument sDoc = SpreadsheetDocument.Open(MyExcelStream, ReadOnly))
                {
                    WorkbookPart workbookPart = sDoc.WorkbookPart;
                    IEnumerable<Sheet> sheets = sDoc.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>();
                    string relationshipId = sheets.First().Id.Value;
                    WorksheetPart worksheetPart = (WorksheetPart)sDoc.WorkbookPart.GetPartById(relationshipId);
                    Worksheet workSheet = worksheetPart.Worksheet;
                    SheetData sheetData = workSheet.GetFirstChild<SheetData>();
                    IEnumerable<Row> rows = sheetData.Descendants<Row>();
                    foreach (Cell cell in rows.ElementAt(0))
                    {
                        dt.Columns.Add(GetCellValue(sDoc, cell));
                    }
                    foreach (Row row in rows) //this will also include your header row...
                    {
                        DataRow tempRow = dt.NewRow();
                        for (int i = 0; i < row.Descendants<Cell>().Count(); i++)
                        {
                            tempRow[i] = GetCellValue(sDoc, row.Descendants<Cell>().ElementAt(i));
                        }
                        dt.Rows.Add(tempRow);
                    }
                }
                dt.Rows.RemoveAt(0);
                return dt;
            }
            public static string GetCellValue(SpreadsheetDocument document, Cell cell)
            {
                SharedStringTablePart stringTablePart = document.WorkbookPart.SharedStringTablePart;
                string value = cell.CellValue.InnerXml;
                if (cell.DataType != null && cell.DataType.Value == CellValues.SharedString)
                {
                    return stringTablePart.SharedStringTable.ChildElements[Int32.Parse(value)].InnerText;
                }
                else
                {
                    return value;
                }
            }
            public static string ConvertDataTableToHTMLTable(DataTable dt)
            {
                string ret = "";
                ret = "<table id=" + (char)34 + "tblExcel" + (char)34 + ">";
                ret+= "<tr>";
                foreach (DataColumn col in dt.Columns)
                {
                    ret += "<td class=" + (char)34 + "tdColumnHeader" + (char)34 + ">" + col.ColumnName + "</td>";
                }
                ret+= "</tr>";
                foreach (DataRow row in dt.Rows)
                {
                    ret+="<tr>";
                    for (int i = 0;i < dt.Columns.Count;i++)
                    {
                        ret+= "<td class=" + (char)34 + "tdCellData" + (char)34 + ">" + row[i].ToString() + "</td>";
                    }
                    ret+= "</tr>";
                }
                ret+= "</table>";
                return ret;
            }
	    }
    }

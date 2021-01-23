    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using TemplateTables.ExcelTemplates;
    using Test;
    using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
    
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                ///////////////////////////////////////////////// Write my data in Excel File
                OpenFileDialog openFileDialog;
    
                var myData = new List<TestData>//My data for test
                {
                    new TestData("a1", "b1", "c1"),
                    new TestData("a2", "b2", "c2"),
                    new TestData("a3", "b3", "c3"),
                    new TestData("a4", "b4", "c4"),
                    new TestData("a5", "b5", "c5"),
                    new TestData("a6", "b6", "c6")
                };
                try
                {
                    var wk = new OfficeFramework.Create.Worker();//general class for work
                    var ex = new TestTable();
                    wk.Export(ex.ExcelTableLines(myData), ex.ExcelTableHeader(), "MyTestTemp");//here i generate DataTeble, labels and send in public void Export(DataTable dataTable, System.Collections.Hashtable hashtable, String templateName) and send my template file name "MyTestTemp"
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
    using System;
    
    namespace Interfaces 
    {
        public interface ITestData // interface for my data
        {
            String AAA { get; }
            String BBB { get; }
            String CCC { get; }
        }
    }
    using System;
    using Interfaces;
    
    namespace Test
    {
        public class TestData : ITestData // my data class
        {
            public String AAA { get; private set; }
            public String BBB { get; private set; }
            public String CCC { get; private set; }
    
            public TestData(String a, String b, String c)
            {
                AAA = a;
                BBB = b;
                CCC = c;
            }
        }
    }
    using System;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    namespace OfficeFramework.Create
    {
        public class CellForFooter // here i will be keep cells for my labels. self cell and value
        {
            public Cell _Cell { get; private set; }
            public String Value { get; private set; }
    
            public CellForFooter(Cell cell, String value)
            {
                _Cell = cell;
                Value = value;
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    namespace OfficeFramework.Create
    {
        public class Footer //it's rows with cells for labels
        {
            public Row _Row { get; private set; }
            public List<CellForFooter> Cells { get; private set; }
    
            public Footer(Row row, Cell cell, String cellValue)
            {
                _Row = new Row((Row) row.Clone()) {RowIndex = row.RowIndex};
                var _Cell = (Cell)cell.Clone();
                _Cell.CellReference = cell.CellReference;
                Cells = new List<CellForFooter> { new CellForFooter(_Cell,cellValue) };
            }
    
            public void AddMoreCell(Cell cell, String cellValue)
            {
                var _Cell = (Cell)cell.Clone();
                _Cell.CellReference = cell.CellReference;
                Cells.Add(new CellForFooter(_Cell, cellValue));
            }
        }
    }
    using System;
    
    namespace OfficeFramework.Create
    {
        public class Field // here i will keep my colums names, rows indexes and column index
        {
            public uint Row { get; private set; }
            public String Column { get; private set; }
            public String _Field { get; private set; }
    
            public Field(uint row, String column, String field)
            {
                Row = row;
                Column = column;
                _Field = field;
            }
        }
    }
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Spreadsheet;
    
    namespace OfficeFramework.Create
    {
        public class Worker
        {
            private const String TemplateFolder = @"C:\ExcelTemplates\";
    
            public static String Directory
            {
                get
                {
                    const string excelFilesPath = @"C:\xls_repository\"; // folder for result files
                    if (System.IO.Directory.Exists(excelFilesPath) == false)
                    {
                        System.IO.Directory.CreateDirectory(excelFilesPath);
                    }
    
                    return excelFilesPath;
                }
            }
    
            public void Export(DataTable dataTable, System.Collections.Hashtable hashtable, String templateName)
            {
                var filePath = CreateFile(templateName);
    
                OpenForRewriteFile(filePath, dataTable, hashtable);
    
                OpenFile(filePath);
            }
    
            private String CreateFile(String templateName)
            {
                if (!File.Exists(TemplateFolder + templateName + ".xlsx"))
                {
                    throw new Exception(String.Format("Не удалось найти шаблон документа \"{0}\"!", TemplateFolder + templateName + ".xlsx"));
                }
    
                var filePath = Directory + templateName + "_" + Regex.Replace((DateTime.Now.ToString(CultureInfo.InvariantCulture)), @"[^a-z0-9]+", "") + ".xlsx";
    
                File.Copy(TemplateFolder + templateName + ".xlsx", filePath, true);
    
                return filePath;
            }
    
            private void OpenForRewriteFile(String filePath, DataTable dataTable, System.Collections.Hashtable hashtable)
            {
                Row rowTemplate = null;
                var footer = new List<Footer>();
                var firsIndexFlag = false; 
                using (var document = SpreadsheetDocument.Open(filePath, true))
                {
                    Sheet sheet;
                    try
                    {
                        sheet = document.WorkbookPart.Workbook.GetFirstChild<Sheets>().Elements<Sheet>().SingleOrDefault(s => s.Name == "Лист1");// get my sheet
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Возможно в документе существует два листа с названием \"Лист1\"!\n",ex);
                    }
    
                    if (sheet==null)
                    {
                        throw new Exception("В шаблоне не найден Лист1!\n");
                    }
    
                    var worksheetPart = (WorksheetPart)document.WorkbookPart.GetPartById(sheet.Id.Value);
                    var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
    
                    var rowsForRemove = new List<Row>();
                    var fields = new List<Field>();
                    foreach (var row in worksheetPart.Worksheet.GetFirstChild<SheetData>().Elements<Row>())
                    {
                        var celsForRemove = new List<Cell>();
                        foreach (var cell in row.Descendants<Cell>())
                        {
                            if (cell == null)
                            {
                                continue;
                            }
    
                            var value = GetCellValue(cell, document.WorkbookPart);
                            if (value.IndexOf("DataField:", StringComparison.Ordinal) != -1)
                            {
                                if (!firsIndexFlag)
                                {
                                    firsIndexFlag = true;
                                    rowTemplate = row;
                                }
                                fields.Add(new Field(Convert.ToUInt32(Regex.Replace(cell.CellReference.Value, @"[^\d]+", ""))
                                    , new string(cell.CellReference.Value.ToCharArray().Where(p => !char.IsDigit(p)).ToArray())
                                    , value.Replace("DataField:", "")));
    
                            }
    
                            if (value.IndexOf("Label:", StringComparison.Ordinal) != -1 && rowTemplate == null)
                            {
                                if (!hashtable.ContainsKey(value.Replace("Label:", "").Trim()))
                                {
                                    throw new Exception("Нет такого лэйбла");
                                }
                                cell.CellValue = new CellValue(hashtable[value.Replace("Label:", "").Trim()].ToString());
                                cell.DataType = new EnumValue<CellValues>(CellValues.String);
    
                            }
    
                            if (rowTemplate == null || row.RowIndex <= rowTemplate.RowIndex || String.IsNullOrWhiteSpace(value))
                            {
                                continue;
                            }
                            var item = footer.SingleOrDefault(p => p._Row.RowIndex == row.RowIndex);
                            if (item == null)
                            {
                                footer.Add(new Footer(row, cell, value.IndexOf("Label:", StringComparison.Ordinal) != -1? hashtable[value.Replace("Label:", "").Trim()].ToString():value));
                            }
                            else
                            {
                                item.AddMoreCell(cell, value.IndexOf("Label:", StringComparison.Ordinal) != -1? hashtable[value.Replace("Label:", "").Trim()].ToString():value);
                            }
                            celsForRemove.Add(cell);
                        }
    
                        foreach (var cell in celsForRemove)
                        {
                            cell.Remove();
                        }
    
                        if (rowTemplate != null && row.RowIndex != rowTemplate.RowIndex)
                        {
                            rowsForRemove.Add(row);
                        }
                    }
    
                    if (rowTemplate == null || rowTemplate.RowIndex == null || rowTemplate.RowIndex<0)
                    {
                        throw new Exception("Не удалось найти ни одного поля, для заполнения!");
                    }
    
                    foreach (var row in rowsForRemove)
                    {
                        row.Remove();
                    }
    
                    var index = rowTemplate.RowIndex;
                    foreach (var row in from DataRow item in dataTable.Rows select CreateRow(rowTemplate, index, item, fields))
                    {
                        sheetData.InsertBefore(row, rowTemplate);
                        index++;
                    }
    
                    foreach (var newRow in footer.Select(item => CreateLabel(item, (UInt32)dataTable.Rows.Count)))
                    {
                        sheetData.InsertBefore(newRow, rowTemplate);
                    }
    
                    rowTemplate.Remove();
                }
            }
    
            private Row CreateLabel(Footer item, uint count)
            {
                var row = item._Row;
                row.RowIndex = new UInt32Value(item._Row.RowIndex + (count - 1));
                foreach (var cell in item.Cells)
                {
                    cell._Cell.CellReference = new StringValue(cell._Cell.CellReference.Value.Replace(Regex.Replace(cell._Cell.CellReference.Value, @"[^\d]+", ""), row.RowIndex.ToString()));
                    cell._Cell.CellValue = new CellValue(cell.Value);
                    cell._Cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    row.Append(cell._Cell);
                }
                return row;
            }
    
            private Row CreateRow(Row rowTemplate, uint index, DataRow item, List<Field> fields)
            {
                var newRow = (Row)rowTemplate.Clone();
                newRow.RowIndex = new UInt32Value(index);
    
                foreach (var cell in newRow.Elements<Cell>())
                {
                    cell.CellReference = new StringValue(cell.CellReference.Value.Replace(Regex.Replace(cell.CellReference.Value, @"[^\d]+", ""), index.ToString(CultureInfo.InvariantCulture)));
                    foreach (var fil in fields.Where(fil => cell.CellReference == fil.Column + index))
                    {
                        cell.CellValue = new CellValue(item[fil._Field].ToString());
                        cell.DataType = new EnumValue<CellValues>(CellValues.String);
                    }
                }
                return newRow;
            }
    
    
            private string GetCellValue(Cell cell, WorkbookPart wbPart)
            {
                var value = cell.InnerText;
    
                if (cell.DataType == null)
                {
                    return value;
                }
                switch (cell.DataType.Value)
                {
                    case CellValues.SharedString:
    
                        var stringTable = wbPart.GetPartsOfType<SharedStringTablePart>().FirstOrDefault();
    
                        if (stringTable != null)
                        {
                            value = stringTable.SharedStringTable.ElementAt(int.Parse(value)).InnerText;
                        }
                        break;
                }
    
                return value;
            }
    
            private void OpenFile(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    throw new Exception(String.Format("Не удалось найти файл \"{0}\"!", filePath));
                }
    
                Process.Start(filePath).WaitForExit();
            }
        }
    }

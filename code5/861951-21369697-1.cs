    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DocumentFormat.OpenXml.Packaging;
    using Ap = DocumentFormat.OpenXml.ExtendedProperties;
    using Vt = DocumentFormat.OpenXml.VariantTypes;
    using DocumentFormat.OpenXml;
    using DocumentFormat.OpenXml.Spreadsheet;
    using A = DocumentFormat.OpenXml.Drawing;
    using System.Globalization;
    
    namespace TesterApp
    {
        public class ShowValuesSample
        {
    
            public String FileName { get; private set; }
    
            private SpreadsheetDocument _ExcelDocument = null;
            public SpreadsheetDocument ExcelDocument
            {
                get
                {
                    if (_ExcelDocument == null)
                    {
                        _ExcelDocument = SpreadsheetDocument.Open(FileName, true);
                    }
                    return _ExcelDocument;
                }
    
            }
            private SheetData _SheetDataOfTheFirstSheet = null;
            public SheetData SheetDataOfTheFirstSheet
            {
                get
                {
                    if (_SheetDataOfTheFirstSheet == null)
                    {
                        WorksheetPart shPart = ExcelDocument.WorkbookPart.WorksheetParts.ElementAt(0);
                        Worksheet wsh = shPart.Worksheet;
                        _SheetDataOfTheFirstSheet = wsh.Elements<SheetData>().ElementAt(0);
                    }
    
                    return _SheetDataOfTheFirstSheet;
                }
            }
            private SharedStringTable _SharedStrings = null;
            public SharedStringTable SharedStrings
            {
                get
                {
                    if (_SharedStrings == null)
                    {
                        SharedStringTablePart shsPart = ExcelDocument.WorkbookPart.SharedStringTablePart;
                        _SharedStrings = shsPart.SharedStringTable;
                    }
                    return _SharedStrings;
                }
            }
    
            public ShowValuesSample(String fileName)
            {
                FileName = fileName;
            }
    
            //In the file descriptions are stored as sharedString 
            //so cellValue it's the zeroBased index of the sharedStringTable
            public String[] GetDescriptions_A2A10()
            {
                String[] retVal = new String[9];
    
                for (int i = 0; i < retVal.Length; i++)
                {
                    Row r = SheetDataOfTheFirstSheet.Elements<Row>().ElementAt(i + 1);
                    Cell c = r.Elements<Cell>().ElementAt(0);
                    Int32 shsIndex = Convert.ToInt32(c.CellValue.Text);
                    SharedStringItem shsItem = SharedStrings.Elements<SharedStringItem>().ElementAt(shsIndex);
                    retVal[i] = shsItem.Text.Text;
                }
                
                return retVal;
            }
    
            //The value it's stored beacause excel does
            //To be sure it's correct you should perform all calculations
            //In this case i'm sure Excel didn't stored the wrong value so..
            public Double GetValue_D11()
            {
                Double retVal = 0.0d;
    
                Int32 cellIndex = 0;
                //cellIndex it's 0 and not 3, cause A11, B11, C11 are empty cells
                //Another issue to deal with ;-)
                Cell c = SheetDataOfTheFirstSheet.Elements<Row>().ElementAt(10).Elements<Cell>().ElementAt(cellIndex);
                
                //as example take a look at the value of storedFormula
                String storedFormula = c.CellFormula.Text;
                String storedValue = c.CellValue.Text;
    
                NumberFormatInfo provider = new NumberFormatInfo();
                provider.NumberDecimalSeparator = ".";
                provider.NumberGroupSeparator = ",";
                provider.NumberGroupSizes = new Int32[] { 3 };
    
                retVal = Convert.ToDouble(storedValue, provider);
    
                return retVal;
            }
        }
    }

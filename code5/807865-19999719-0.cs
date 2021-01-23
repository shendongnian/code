    public class ExcelModel
    {
        Application excelApp;
        string newValue;
        public ExcelModel(string newValue)
        {
            excelApp = new Application();
            this.newValue = newValue;
        }
        public void openExcelSheet(string fileName)
        {
            Workbook workbook = excelApp.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            Worksheet sheet = (Worksheet)workbook.Worksheets.get_Item(2);
            double oldValue = sheet.get_Range("D6").get_Value();
            
            sheet.Cells[6, 4] = newValue;
            workbook.SaveAs("\\Users\\user1\\Downloads\\text3.xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            workbook.Close();
            excelApp.Visible = true;
            Workbook newWorkbook = excelApp.Workbooks.Open("\\Users\\user1\\Downloads\\text3.xlsx");
        }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateExcel(string field, int id = 0)
        {
            ExcelModel model = new ExcelModel(field);
            string file = "\\Users\\user1\\Downloads\\Testdocument.xlsx";
            model.openExcelSheet(file);
            return RedirectToAction("Index");
            
        }
        public List<Record> RecordInfo(string fieldname = "test")
        {
            List<Record> Recordobj = new List<Record>();
            Recordobj.Add(new Record { Fieldname = fieldname });
            return Recordobj;
        }
    }

    public partial class Form1 : Form
    {   
        private void button1_Click(object sender, EventArgs e)
        {
            Application excelApplication = new Excel.Application
            {
                Visible = true,
                ScreenUpdating = true,
                DecimalSeparator = ".",
                ThousandsSeparator = ",",
                UseSystemSeparators = false
            };
    
            _Workbook workbook = excelApplication.Workbooks.Add();
            _Worksheet sheet = workbook.Worksheets[1];
            Range range = sheet.Range["A1"];
            range.Formula = "1,234,567.89";
    
            // re-set
            excelApplication.UseSystemSeparators = true;
    
            excelApplication.Quit();
        }
    }

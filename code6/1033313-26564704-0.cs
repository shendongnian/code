    public partial class MainWindow : Window
    {
        // Declare a private member in your MainWindow
        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Assign to our private member only once, at the first button click
            if (xlWorkSheet == null)
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add();
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.ActiveSheet;
            }
            // After the second button click, we already have a reference 
            // to a work sheet, so we can just write to it.
            xlWorkSheet.Cells[1, 1] = 10; // Just an example.
            // DON'T close the excel application here.
        }

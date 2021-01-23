        static void Main(string[] args)
        {
            //Application.WorkbookBeforeSave += new Excel.AppEvents_WorkbookBeforeSaveEventHandler(Application_WorkbookBeforeSave);
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("Contact No");
            dt.Columns.Add("NIC");
            foreach (string txtName in Directory.GetFiles(@"D:\unityapp\tab02", "*.txt"))
            {
                StreamReader sr = new StreamReader(txtName);
                //string line = "Name: Address: Contact No:  NIC No:";
                string[] token1 = sr.ReadLine().Split(new string[] { "Name: ", "Address: ", "Contact No: ", "NIC No:" }, StringSplitOptions.None);
	dt.Rows.Add(token1[1], token1[2], token1[3], token1[4]);
                   
                
            }
           Microsoft.Office.Interop.Excel.Application x = new Microsoft.Office.Interop.Excel.Application();
         //  Workbook wb = x.Workbooks.Open(@"C:\Book1.xlsx");
           Workbook wb = x.Workbooks.Add();
           Worksheet sheet = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.get_Item(1);
        // Microsoft.Office.Interop.Excel.Workbook wb = new Microsoft.Office.Interop.Excel.Workbook();
        // Microsoft.Office.Interop.Excel.Worksheet sheet = new Microsoft.Office.Interop.Excel.Worksheet();
            sheet.Cells[1, 1] = "Name";
            sheet.Cells[1, 1].Interior.ColorIndex = 10;
            sheet.Cells[1, 2] = "Address";
            sheet.Cells[1, 2].Interior.ColorIndex = 20;
            sheet.Cells[1, 3] = "Contact No";
            sheet.Cells[1, 3].Interior.ColorIndex = 30;
            sheet.Cells[1, 4] = "NIC";
            sheet.Cells[1, 4].Interior.ColorIndex = 40;
            int rowCounter = 2;
            int columnCounter = 1;
            foreach (DataRow dr in dt.Rows)
            {
               
                sheet.Cells[rowCounter, columnCounter] = dr["Name"].ToString();
                columnCounter += 1;
                sheet.Cells[rowCounter, columnCounter] = dr["Address"].ToString();
                columnCounter += 1;
                sheet.Cells[rowCounter, columnCounter] = dr["Contact No"].ToString();
                columnCounter += 1;
                sheet.Cells[rowCounter, columnCounter] = dr["NIC"].ToString();
                rowCounter += 1;
                columnCounter = 1;
            }
            wb.SaveAs(@"D:\Unity.xlsx");
            wb.Close();
            x.Quit();
            Process.Start(@"D:\Unity.xlsx");
        }
    }
}

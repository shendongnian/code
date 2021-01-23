        //...
        using Office = Microsoft.Office.Core;
        using Excel = Microsoft.Office.Interop.Excel;
        using ios = System.Runtime.InteropServices;
        //...
        private void btnDeleteChart_Click(object sender, EventArgs e)
        {
            Excel.Application xl = GetExcel();
            if (xl == null) return;
            
            Excel.Workbook wb = xl.ActiveWorkbook;
            Excel.Worksheet sht = wb.ActiveSheet;
            Excel.Range rSrch = sht.Range["B4:D8"];
            
            Excel.Range rShp;
            
            foreach (Excel.Shape shp in sht.Shapes)
            if (shp.Type ==  Office.MsoShapeType.msoChart)
            {
                rShp = shp.TopLeftCell;
                if(xl.Intersect(rShp,rSrch)!=null)shp.Delete();
            }
        }
        private Excel.Application GetExcel()
        {
            Excel.Application xl = 
              (Excel.Application)ios.Marshal.GetActiveObject("Excel.Application");
            if (xl == null) MessageBox.Show("No Excel !!");
            return xl; 
        }

            Workbook w = a.Workbooks.Open(@"C:\SCRATCH\Libro2.xlsx");
            Worksheet ws = w.Sheets["Report"];
            ws.Protect(Contents: false);
            Range r = ws.Range["B2:H20"];
            r.CopyPicture(XlPictureAppearance.xlScreen, XlCopyPictureFormat.xlBitmap);
                
            Bitmap image = new Bitmap(Clipboard.GetImage());
            image.Save(@"C:\SCRATCH\image.png");
            // charting code, replaced with the above 
                   /* ChartObject chartObj = ws.ChartObjects().Add(r.Left, r.Top, r.Width, r.Height); 
    
                    chartObj.Activate();
                    Chart chart = chartObj.Chart;
                    chart.Paste();
                    chart.Export(@"C:\SCRATCH\image.JPG", "JPG");
                    chartObj.Delete(); */

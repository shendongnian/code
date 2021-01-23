            Excel.Application xlApp = new Excel.Application();
            xlApp.DisplayAlerts = false;
            xlApp.Visible = false;
            var xlWorkbook = xlApp.Workbooks.Open(fileInfo.FullName);
            
            // do work
            xlWorkbook.Saved = true;
            xlWorkbook.Close(false, Missing.Value, Missing.Value);
            xlApp.Quit();

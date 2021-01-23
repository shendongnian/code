     var files = Directory.GetFiles(@"C:\temp\", "*.jpg");
            foreach (var i in files)
            {
                var objPrintImage = System.Drawing.Image.FromFile(i);
                var objPrintDoc = new PrintDocument();
                if (objPrintDoc.PrinterSettings.IsValid)
                {
                    objPrintDoc.Print();
                }
            }

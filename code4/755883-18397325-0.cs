      foreach (var i in files)
        {
            using(var objPrintImage = Image.FromFile(i))
            {
            objDimension = new FrameDimension(new System.Guid());
            PrintDocument objPrintDoc = new PrintDocument();
            objPrintDoc.PrintPage += new PrintPageEventHandler(this.objPrintDoc_PrintPage);
            if (objPrintDoc.PrinterSettings.IsValid)
            {
                objPrintDoc.Print();
            }
            }
        }

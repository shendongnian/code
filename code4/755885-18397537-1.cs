     var files = Directory.GetFiles(@"C:\temp\", "*.jpg");
            foreach (var i in files)
            {         
                var objPrintDoc = new PrintDocument();
                objPrintDoc.PrintPage += (obj, eve) =>
                    {
                        System.Drawing.Image img = System.Drawing.Image.FromFile(i);
                        Point loc = new Point(100, 100);
                        e.Graphics.DrawImage(img, loc);
                    };
                objPrintDoc.Print();       
            }

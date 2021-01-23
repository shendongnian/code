                    DataRow row = dataTable.NewRow();
    
                    string barcode = "*" + ID.ToString() + VALOR_VENDA.Value.ToString() + "*";
    
                    row["nome"] = NOME_PRODUTO;
                    row["preco"] = VALOR_VENDA.Value;
    
                    int w = barcode.Length * 40;
                    Bitmap oBitmap = new Bitmap(w, 100);
                    Graphics oGraphics = Graphics.FromImage(oBitmap);
                    Font oFont = new Font("IDAutomationHC39M", 18);
                    PointF oPoint = new PointF(2f, 2f);
                    SolidBrush oBrushWrite = new SolidBrush(Color.Black);
                    SolidBrush oBrush = new SolidBrush(Color.White);
                    oGraphics.FillRectangle(oBrush, 0, 0, w, 100);
                    oGraphics.DrawString(barcode, oFont, oBrushWrite, oPoint);

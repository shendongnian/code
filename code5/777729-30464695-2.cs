                ColumnText ct = new ColumnText(cb);
                cb.BeginText();
                cb.SetFontAndSize(BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED), 12.0f);
                //Note, (0,0) in this case is at the bottom of the document
                cb.SetTextMatrix(document.LeftMargin, document.BottomMargin); 
                cb.ShowText(String.Format("{0} {1}", "Testing Text", "Like this"));
                cb.EndText();

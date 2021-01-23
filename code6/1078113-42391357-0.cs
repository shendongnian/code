        public bool drawVerticalText(string _text, Color _color, int _angle, int _size, int _left, int _top)
        {
            try
            {
                BaseColor bc = new BaseColor(_color.R, _color.G, _color.B, _color.A);
                PdfContentByte cb = writer.DirectContent;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
                //int width = baseFont.GetWidth(_text);
                cb.BeginText();
                cb.SetColorFill(CMYKColor.RED);
                cb.SetFontAndSize(bf, _size);
                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, _text, _left, document.Top - _top, _angle);
                cb.EndText();
                document.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

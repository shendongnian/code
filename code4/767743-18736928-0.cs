     PdfContentByte cb = stamper.GetOverContent(x);
                            iTextSharp.text.Rectangle rectangle = new iTextSharp.text.Rectangle(370, 750, 140, 790);
                            rectangle.BackgroundColor = new BaseColor(Color.FromArgb(147, 146, 152));
                            cb.Rectangle(rectangle);
                            BaseFont baseFont = BaseFont.CreateFont("times.ttf"/*BaseFont.HELVETICA*/, /*BaseFont.CP1250*/ BaseFont.IDENTITY_H, BaseFont.EMBEDDED/*BaseFont.NOT_EMBEDDED*/);
                            cb.SetColorFill(BaseColor.WHITE);
                            cb.SetFontAndSize(baseFont, 21);
                            cb.BeginText();
                            string appendto = "\u00A3" + textBox1.Text;
                            if (!checkBox1.Checked)
                            {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, appendto, 235, 764, 0);
                            }
                            else if (checkBox1.Checked)
                            {
                                cb.ShowTextAligned(PdfContentByte.ALIGN_CENTER, appendto, 260, 764, 0);
                            }
                            cb.EndText();

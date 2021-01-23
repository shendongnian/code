          // Get the contents of my page...
          PdfObject pdfObject = pageDict.GetDirectObject(PdfName.CONTENTS);
          // Check that this is, in fact, an array or something else...
          if (pdfObject.IsArray())
          {
              PdfArray streamArray = pageDict.GetAsArray(PdfName.CONTENTS);
              for (int j = 0; j < streamArray.Size; j++)
                 {
                      PdfIndirectReference arrayEl = (PdfIndirectReference)streamArray[j];
                      PdfObject refdObj = reader.GetPdfObject(arrayEl.Number);
                      if (refdObj.IsStream())
                         {
                            PRStream stream = (PRStream)refdObj;
                            byte[] data = PdfReader.GetStreamBytes(stream);
                            stream.SetData(System.Text.Encoding.ASCII.GetBytes(System.Text.Encoding.ASCII.GetString(data).Replace(targetedText, newText)));
                         }
                  }
           }

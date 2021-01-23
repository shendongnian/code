                  int i = 1;
                  foreach (Word.Paragraph aPar in oDoc.Paragraphs)
                  {
                  string sText = aPar.Range.Text;
                 if (sText != "\r")
                 {
                   if (sText == para[1].ToString() + "\r")
                   {
                   Word.Range range = oDoc.Paragraphs[i + 1].Range;
                   if (!range.Text.Contains("GUID:"))
                       {
                           int pEnd = aPar.Range.End;
                           string guid = "GUID:" + para[0].Replace("{", "").Replace("}", "");
                           int length = guid.Length;
                           aPar.Range.InsertAfter(guid);
                           Word.Range parRng = oDoc.Range(pEnd, pEnd + length);
                           parRng.Font.Hidden = 1;
                           parRng.InsertParagraphAfter();
                           }
                         }
                       }
                       i++;
                     }

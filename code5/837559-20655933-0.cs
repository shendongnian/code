    var doc = new Document(PageSize.A4, 5f, 5f, 5f, 5f);
    try
    {
         var mem = new MemoryStream();
         try
         {
             PdfWriter wri = PdfWriter.GetInstance(doc, output);
             doc.Open();
             AddContent(ref doc,ref wri );
             doc.Close();
         }
         finally
         {
             if (mem != null)
                 ((IDisposable)mem).Dispose();
         }
     }
     finally
     {
         if (doc != null)
             ((IDisposable)doc).Dispose();
     }
     return output.ToArray();

    public static byte[] MergePDFs(byte[][] sourceFiles) {
		using (var dest = new System.IO.MemoryStream())
		using (var document = new iTextSharp.text.Document()) 
		using (var writer = new iTextSharp.text.pdf.PdfCopy(document, dest)) {
			document.Open();
			foreach (var pdf in sourceFiles) {
				using (var r = new iTextSharp.text.pdf.PdfReader(pdf))
					writer.AddDocument(r);
			}
			document.Close();
			return dest.ToArray();
		}
	}

		public static void ExtractAttachments(String src, String dir)
		{
			PdfReader reader = new PdfReader(string.Format("{0}\\{1}", dir, src));
			PdfDictionary root = reader.Catalog;
			PdfDictionary names = root.GetAsDict(PdfName.NAMES);
			PdfDictionary embedded = names.GetAsDict(PdfName.EMBEDDEDFILES);
			PdfArray filespecs = embedded.GetAsArray(PdfName.NAMES);
			for (int i = 0; i < filespecs.Size; )
			{
				ExtractAttachment(reader, dir, filespecs.GetAsString(i++),
				filespecs.GetAsDict(i++));
			}
		}
		protected static void ExtractAttachment(PdfReader reader, string dir, PdfString name, PdfDictionary filespec)
		{
			PRStream stream;
			FileStream fos;
			String filename;
			PdfDictionary refs = filespec.GetAsDict(PdfName.EF);
			foreach(PdfName key in refs.Keys) {
				stream = (PRStream)PdfReader.GetPdfObject(refs.GetAsIndirectObject(key));
				filename = filespec.GetAsString(key).ToString();
				// here you can do an filename.Contains(".swf) check
				var fileBytes = PdfReader.GetStreamBytes(stream);
				File.WriteAllBytes(string.Format("{0}\\{1}", dir, filename), fileBytes);
				}
			}

     public static void RemoveNotesFromDoc(string docPath)
        {
            try
            {
                using (PresentationDocument pDoc =
                    PresentationDocument.Open(docPath, true))
                {
                    foreach (var slide in pDoc.PresentationPart.SlideParts)
                    {
                        NotesSlidePart notes = slide.NotesSlidePart;
                        if (notes != null)
                        {
                            slide.DeletePart(slide.GetIdOfPart(slide.NotesSlidePart));
                        }
					}
				}
			}
		}

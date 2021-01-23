    public static Boolean CycleAnnotations(PdfReader reader, int pageIndex, PdfJob job)
            {
                List<string> keys = job.ConfigurationSettings.Where(cfs => cfs.Condition != null).Select(cs => cs.Condition).ToList();
                bool found = CycleAnnotations(reader, pageIndex, keys);
                if (found)
                {
                    return found;
                }
                else
                {
                    return CycleAnnotations(reader, pageIndex, "MT(TR3)"); //default key
                }
            }
            public static Boolean CycleAnnotations(PdfReader reader, int pageIndex, string key)
            {
                PdfDictionary pdfDictionary = reader.GetPageN(pageIndex);
                PdfArray annots = pdfDictionary.GetAsArray(PdfName.ANNOTS);
                if (annots != null)
                {
                    foreach (var iter in annots)
                    {
                        PdfDictionary annot = (PdfDictionary)PdfReader.GetPdfObject(iter);
                        PdfString content = (PdfString)PdfReader.GetPdfObject(annot.Get(PdfName.CONTENTS));
                        if (content != null)
                        {
                            if (Utilities.IsAnnotationFound(content, key))
                            {
                                return true;
                            }
                        }
                    }
                }
                return false;
            }
            public static Boolean CycleAnnotations(PdfReader reader, int pageIndex, List<string> keys)
            {
                PdfDictionary pdfDictionary = reader.GetPageN(pageIndex);
                PdfArray annots = pdfDictionary.GetAsArray(PdfName.ANNOTS);
                foreach (string keyItem in keys)
                {
                    if (annots != null)
                    {
                        foreach (var iter in annots)
                        {
                            PdfDictionary annot = (PdfDictionary)PdfReader.GetPdfObject(iter);
                            PdfString content = (PdfString)PdfReader.GetPdfObject(annot.Get(PdfName.CONTENTS));
                            if (content != null)
                            {
                                if (Utilities.IsAnnotationFound(content, keyItem))
                                {
                                    return true;
                                }
                            }
                        }
                    }
                }

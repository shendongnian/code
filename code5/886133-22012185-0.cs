     Document doc = new Document();
                PdfSmartCopy pdfCopy = new PdfSmartCopy(doc, ms);
                doc.Open();
                foreach (var percorsoFilePdf in files)
                {
                    PdfReader reader = new PdfReader(percorsoFilePdf);
                    int numpagine = reader.NumberOfPages;
                    for (int I = 1; I <= numpagine-PageAddedByWord; I++)
                    {
                        doc.SetPageSize(reader.GetPageSizeWithRotation(1));
                        PdfImportedPage page = pdfCopy.GetImportedPage(reader, I);
                        pdfCopy.AddPage(page);
                    }
                    //Clean up
                    //pdfCopy.FreeReader(reader);
                    reader.Close();
                }
                //Clean up
                doc.Close();
                SharedMethods.MemoryStreamToFile(ms, PdfOutputFile);

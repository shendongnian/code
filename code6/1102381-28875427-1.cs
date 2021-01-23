        void GeneratePDFWithProgressWithCreate(string wordFilename, string pdfFilename)        
        {       
                // Update Progress bar to see start of threads         
                UpdateProgress();
                // Setup Word Application
                Microsoft.Office.Interop.Word.Application wordAppPrivate = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document wordDocument = wordAppPrivate.Documents.Open(wordFilename, false);
                wordDocument.ExportAsFixedFormat(pdfFilename, WdExportFormat.wdExportFormatPDF);
                object saveOption = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                if (wordDocument != null) 
                    ((_Document)wordDocument).Close(ref saveOption, ref originalFormat, ref routeDocument);
                if (wordAppPrivate != null)
                    ((_Application)wordAppPrivate).Quit(ref saveOption, ref originalFormat, ref routeDocument);
                if (wordDocument != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordDocument);
                
                if (wordAppPrivate != null)
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordAppPrivate);
                wordDocument = null;
                wordAppPrivate = null;
                //GC.Collect(); // force final cleanup!
                // Update progress bar to see finishing the conversion
                UpdateProgress();               
            //}
        }

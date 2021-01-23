            private void ConvertPowerpointToPdf(string inputFile, string outputFile)
            {
                var powerPointApp = new Microsoft.Office.Interop.PowerPoint.ApplicationClass();
                Presentation presentation = null;
                Presentations presentationList = null;
                try
                {
                    presentationList = powerPointApp.Presentations;
                    presentation = presentationList.Open(inputFile, ReadOnly: MsoTriState.msoFalse, WithWindow: MsoTriState.msoFalse, Untitled: MsoTriState.msoFalse);
                    presentation.ExportAsFixedFormat(outputFile, PpFixedFormatType.ppFixedFormatTypePDF,
                    PpFixedFormatIntent.ppFixedFormatIntentScreen, MsoTriState.msoFalse,
                    PpPrintHandoutOrder.ppPrintHandoutVerticalFirst, PpPrintOutputType.ppPrintOutputSlides,
                    MsoTriState.msoFalse, null, PpPrintRangeType.ppPrintAll, string.Empty, false, true, true, true, false,
                    Type.Missing);
                }
                finally
                {
                    if (presentation != null)
                    {
                        presentation.Close();
                        Release(presentation);
                    }
                    bool allowQuit = true;
                    if (presentationList != null)
                    {
                        allowQuit = presentationList.Count == 0;
                        Release(presentationList);
                    }
                    if(allowQuit)
                        powerPointApp.Quit();
                    Release(powerPointApp);
                }
            }

    private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                var webbrowser = webBrowser1.ActiveXInstance as SHDocVw.IWebBrowser2;
                var document =webbrowser.Document;
                if (document != null)
                {
                    var wordDocument = document as Microsoft.Office.Interop.Word.Document ;
                    if (wordDocument != null)
                    {
                        var activeWindow=wordDocument.ActiveWindow;
                        if (activeWindow != null)
                        {
                            var view=activeWindow.View;
                            if (view != null)
                            {
                                view.Type = WdViewType.wdPrintView;
                                Marshal.ReleaseComObject(view);
                            }
                            Marshal.ReleaseComObject(activeWindow);
                        }
                        Marshal.ReleaseComObject(wordDocument);
                    }
                    Marshal.ReleaseComObject(document);
                }
                Marshal.ReleaseComObject(webbrowser);
            }
        }

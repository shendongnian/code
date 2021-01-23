                private Object excelLock = new Object();                
                lock (wordLock)
                {
                    officeApp = new Microsoft.Office.Interop.Word.Application();
                }

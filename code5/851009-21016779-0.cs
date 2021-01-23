                // try to open word
                Type typeWordApplication = Type.GetTypeFromProgID("Word.Application");
                if (typeWordApplication == null)
                    throw new Exception("Word is not installed (Word.Application is not found)");
                object objWordApplication = Activator.CreateInstance(typeWordApplication);
                object objDocuments = objWordApplication.GetType().InvokeMember("Documents", BindingFlags.GetProperty, null, objWordApplication, null);
                object[] param = new object[] { Missing.Value, Missing.Value, Missing.Value, Missing.Value };
                object objDocument = objDocuments.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, objDocuments, param);
                object start = 0;
                object end = 0;
                object objRange = objDocument.GetType().InvokeMember("Range", BindingFlags.InvokeMethod, null, objDocument, new object[] { start, end });
                // set text
                objRange.GetType().InvokeMember("Text", BindingFlags.SetProperty, null, objRange, new object[] { text });
                // set font
                object objFont = objRange.GetType().InvokeMember("Font", BindingFlags.GetProperty, null, objRange, null);
                objFont.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, objFont, new object[] { "Courier" });
                objFont.GetType().InvokeMember("Size", BindingFlags.SetProperty, null, objFont, new object[] { (float)8 });
                start = objRange.GetType().InvokeMember("End", BindingFlags.GetProperty, null, objRange, null);
                end = start;
                objRange = objDocument.GetType().InvokeMember("Range", BindingFlags.InvokeMethod, null, objDocument, new object[] { start, end });
                // select text
                objRange.GetType().InvokeMember("Select", BindingFlags.InvokeMethod, null, objRange, null);
                objWordApplication.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, objWordApplication, new object[] { true });
                Marshal.ReleaseComObject(objWordApplication);

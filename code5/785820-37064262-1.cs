    //using MS word introp object   
    
     public static List<KeyValuePair<string, string>> GetBoldItalicUnderline(string strfilename, int style)//style=1 is bold and style=2 is italic and style=3
            {
                Microsoft.Office.Interop.Word.Application Objword = new Microsoft.Office.Interop.Word.Application();
                List<KeyValuePair<string, string>> data = new List<KeyValuePair<string, string>>();
                //creating the object of document class  
                Document objdoc = new Document();
               // Document objdoc = Objword.Documents.Add();
                try
                {
                    dynamic FilePath = strfilename;
                    dynamic NA = System.Type.Missing;
                    objdoc = Objword.Documents.Open
                                  (ref FilePath, ref NA, ref NA, ref NA, ref NA,
                                   ref NA, ref NA, ref NA, ref NA,
                                   ref NA, ref NA, ref NA, ref NA,
                                   ref NA, ref NA, ref NA
                                   );
                    if (style == 1)
                    {
                        Microsoft.Office.Interop.Word.Range rng = objdoc.Content;
                        Microsoft.Office.Interop.Word.Find find = rng.Find;
                        find.Font.Bold = 1;
                        find.Format = true;
                        while (find.Execute())
                        {
                            data.Add(new KeyValuePair<string, string>(rng.Text, "Bold"));
                        }
                    }
                    if (style == 2)
                    {
                        Microsoft.Office.Interop.Word.Range rngitalic = objdoc.Content;
                        Microsoft.Office.Interop.Word.Find finditalic = rngitalic.Find;
                        finditalic.Font.Italic = 1;
                        finditalic.Format = true;
                        while (finditalic.Execute())
                        {
                            data.Add(new KeyValuePair<string, string>(rngitalic.Text, "Italic"));
                        }
                    }
                    if (style == 3)
                    {
                        //Simgle Underline
                        Microsoft.Office.Interop.Word.Range rngunderline = objdoc.Content;
                        Microsoft.Office.Interop.Word.Find findunderline = rngunderline.Find;
                        findunderline.Font.Underline = WdUnderline.wdUnderlineSingle;
                        findunderline.Format = true;
                        while (findunderline.Execute())
                        {
                            // data.Add(rngunderline.Text);
                            data.Add(new KeyValuePair<string, string>(rngunderline.Text, "wdUnderlineSingle"));
                        }
                        //Dash
                        Microsoft.Office.Interop.Word.Range rngunderlineDash = objdoc.Content;
                        Microsoft.Office.Interop.Word.Find findunderlineDash = rngunderlineDash.Find;
                        findunderlineDash.Font.Underline = WdUnderline.wdUnderlineDash;
                        findunderlineDash.Format = true;
                        while (findunderlineDash.Execute())
                        {
                            //data.Add(rngunderlineDash.Text);
                            data.Add(new KeyValuePair<string, string>(rngunderlineDash.Text, "wdUnderlineDash"));
                        }
                        //DashHeavy
    
                    
    
    Microsoft.Office.Interop.Word.Range rngunderlineDashHeavy = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDashHeavy = rngunderlineDashHeavy.Find;
                    findunderlineDashHeavy.Font.Underline = WdUnderline.wdUnderlineDashHeavy;
                    findunderlineDashHeavy.Format = true;
                    while (findunderlineDashHeavy.Execute())
                    {
                        //  data.Add(rngunderlineDashHeavy.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDashHeavy.Text, "wdUnderlineDashHeavy"));
                    }
                    //DashLong
                    Microsoft.Office.Interop.Word.Range rngunderlineDashLong = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDashLong = rngunderlineDashLong.Find;
                    findunderlineDashLong.Font.Underline = WdUnderline.wdUnderlineDashLong;
                    findunderlineDashLong.Format = true;
                    while (findunderlineDashLong.Execute())
                    {
                        // data.Add(rngunderlineDashLong.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDashLong.Text, "wdUnderlineDashLong"));
                    }
                    //DashLongHeavy
                    Microsoft.Office.Interop.Word.Range rngunderlineDashLonghv = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDashLonghv = rngunderlineDashLonghv.Find;
                    findunderlineDashLonghv.Font.Underline = WdUnderline.wdUnderlineDashLongHeavy;
                    findunderlineDashLonghv.Format = true;
                    while (findunderlineDashLonghv.Execute())
                    {
                        // data.Add(rngunderlineDashLonghv.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDashLonghv.Text, "wdUnderlineDashLongHeavy"));
                    }
                    //DotDash
                    Microsoft.Office.Interop.Word.Range rngunderlineDotDash = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDotDash = rngunderlineDotDash.Find;
                    findunderlineDotDash.Font.Underline = WdUnderline.wdUnderlineDotDash;
                    findunderlineDotDash.Format = true;
                    while (findunderlineDotDash.Execute())
                    {
                        //data.Add(rngunderlineDotDash.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDotDash.Text, "wdUnderlineDotDash"));
                    }
                    //DotDashHeavy
                    Microsoft.Office.Interop.Word.Range rngunderlineDotDashHv = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDotDashHv = rngunderlineDotDashHv.Find;
                    findunderlineDotDashHv.Font.Underline = WdUnderline.wdUnderlineDotDashHeavy;
                    findunderlineDotDashHv.Format = true;
                    while (findunderlineDotDashHv.Execute())
                    {
                        //data.Add(rngunderlineDotDashHv.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDotDashHv.Text, "wdUnderlineDotDashHeavy"));
                    }
                    //DotDotDash
    
                    Microsoft.Office.Interop.Word.Range rngunderlineDotDotDash = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDotDotDash = rngunderlineDotDotDash.Find;
                    findunderlineDotDotDash.Font.Underline = WdUnderline.wdUnderlineDotDotDash;
                    findunderlineDotDotDash.Format = true;
                    while (findunderlineDotDotDash.Execute())
                    {
                        // data.Add(rngunderlineDotDotDash.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDotDotDash.Text, "wdUnderlineDotDotDash"));
                    }
    
                    //DotDotDashHeavy
                    Microsoft.Office.Interop.Word.Range rngunderlineDotDotDashHv = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDotDotDashHv = rngunderlineDotDotDashHv.Find;
                    findunderlineDotDotDashHv.Font.Underline = WdUnderline.wdUnderlineDotDotDashHeavy;
                    findunderlineDotDotDashHv.Format = true;
                    while (findunderlineDotDotDashHv.Execute())
                    {
                        //data.Add(rngunderlineDotDotDashHv.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDotDotDashHv.Text, "wdUnderlineDotDotDashHeavy"));
                    }
                    //Dotted
                    Microsoft.Office.Interop.Word.Range rngunderlineDotted = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDotted = rngunderlineDotted.Find;
                    findunderlineDotted.Font.Underline = WdUnderline.wdUnderlineDotted;
                    findunderlineDotted.Format = true;
                    while (findunderlineDotted.Execute())
                    {
                        // data.Add(rngunderlineDotted.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDotted.Text, "wdUnderlineDotted"));
                    }
                    //DottedHeavy
                    Microsoft.Office.Interop.Word.Range rngunderlineDottedHv = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDottedHv = rngunderlineDottedHv.Find;
                    findunderlineDottedHv.Font.Underline = WdUnderline.wdUnderlineDottedHeavy;
                    findunderlineDottedHv.Format = true;
                    while (findunderlineDottedHv.Execute())
                    {
                        //data.Add(rngunderlineDottedHv.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDottedHv.Text, "wdUnderlineDottedHeavy"));
                    }
                    //DoubleUnderline
                    Microsoft.Office.Interop.Word.Range rngunderlineDouble = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineDouble = rngunderlineDouble.Find;
                    findunderlineDouble.Font.Underline = WdUnderline.wdUnderlineDouble;
                    findunderlineDouble.Format = true;
                    while (findunderlineDouble.Execute())
                    {
                        // data.Add(rngunderlineDouble.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineDouble.Text, "wdUnderlineDouble"));
                    }
                    //Thick
                    Microsoft.Office.Interop.Word.Range rngunderlineThick = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineThick = rngunderlineThick.Find;
                    findunderlineThick.Font.Underline = WdUnderline.wdUnderlineThick;
                    findunderlineThick.Format = true;
                    while (findunderlineThick.Execute())
                    {
                        // data.Add(rngunderlineThick.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineThick.Text, "wdUnderlineThick"));
                    }
                    //Wavy
                    Microsoft.Office.Interop.Word.Range rngunderlineWavy = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineWavy = rngunderlineWavy.Find;
                    findunderlineWavy.Font.Underline = WdUnderline.wdUnderlineWavy;
                    findunderlineWavy.Format = true;
                    while (findunderlineWavy.Execute())
                    {
                        // data.Add(rngunderlineWavy.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineWavy.Text, "wdUnderlineWavy"));
                    }
                    //wavyDouble
                    Microsoft.Office.Interop.Word.Range rngunderlineWavyDbl = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineWavyDbl = rngunderlineWavyDbl.Find;
                    findunderlineWavyDbl.Font.Underline = WdUnderline.wdUnderlineWavyDouble;
                    findunderlineWavyDbl.Format = true;
                    while (findunderlineWavyDbl.Execute())
                    {
                        //data.Add(rngunderlineWavyDbl.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineWavyDbl.Text, "wdUnderlineWavyDouble"));
                    }
                    //WavyHeavy
                    Microsoft.Office.Interop.Word.Range rngunderlineWavyHv = objdoc.Content;
                    Microsoft.Office.Interop.Word.Find findunderlineWavyHv = rngunderlineWavyHv.Find;
                    findunderlineWavyHv.Font.Underline = WdUnderline.wdUnderlineWavyHeavy;
                    findunderlineWavyHv.Format = true;
                    while (findunderlineWavyHv.Execute())
                    {
                        //  data.Add(rngunderlineWavyHv.Text);
                        data.Add(new KeyValuePair<string, string>(rngunderlineWavyHv.Text, "wdUnderlineWavyHeavy"));
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objdoc != null)
                {
                    ((_Document)objdoc).Close();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(objdoc);
                    objdoc = null;
                }
                Process[] processes = Process.GetProcessesByName("winword");
                foreach (var process in processes)
                {
                    process.Close();
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

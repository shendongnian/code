    if (File.Exists(nFile2)) File.Delete(nFile2);
					traceFile2 =  new FileStream(nFile2, FileMode.Open, FileAccess.Write, FileShare.ReadWrite);
                    if (traceFile2 != null)
                    {
                        var twt2 = new TextWriterTraceListener(traceFile2);
     
                        // http://www.helixoft.com/blog/archives/20
                        try
                        {
                            if (twt2.Writer is StreamWriter)
                            {
                                (twt2.Writer as StreamWriter).AutoFlush = true;
                            }
                        }
                        catch { }
     
                        var indiceTraceFile2 = Trace.Listeners.Add(twt2);
                        System.Diagnostics.Trace.WriteLine("INICIO: " + DateTime.Now.ToString());

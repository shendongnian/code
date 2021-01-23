    using StatConnectorCommonLib;
    using STATCONNECTORSRVLib;
    using STATCONNECTORCLNTLib;
                StatConnectorClass rConn = new StatConnectorClass();
                try
                {
      
      
                    rConn.Init("R"); // here is where we initialize R 
                    Response.Write("Initialized." + "<br />"); Response.Flush();
                    Response.Write("1" + "<br />"); Response.Flush();
                    string path = @"C:SOMEPATH\Black-Scholes.RData";
                    rConn.SetSymbol("path", path); 
                    Response.Write("2" + "<br />"); Response.Flush();
                    rConn.Evaluate("load(path)");
                    Response.Write("3" + "<br />"); Response.Flush();
                    Int16 entry = 27; 
                    rConn.SetSymbol("n1", entry);
                    Response.Write("6" + "<br />"); Response.Flush();
                    rConn.Evaluate("x1<-samplefn(n1)" ); 
                    Response.Write("Entered : " + entry.ToString() + "<br/> "); 
                    Object o = rConn.GetSymbol("x1");
                    Response.Write("Ans:" + o.ToString() +  "<br />"); Response.Flush();
                    rConn.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message );//+ " xx " +  rConn.GetErrorText());
                    rConn.Close();
                }

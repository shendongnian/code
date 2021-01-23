    private void DoReleaseCOMObject(object obj)
            {
                int refCounter = Marshal.ReleaseComObject(obj);
                while (refCounter > 0)
                {
                    refCounter = Marshal.ReleaseComObject(obj);
                    System.Diagnostics.Debug.WriteLine("ReleaseCOM ref: " + refCounter);
                }
    
                obj = null;
            }
     private void DoFinalReleaseCOMObject(object obj)
            {
                int refCounter = Marshal.FinalReleaseComObject(obj);
                System.Diagnostics.Debug.WriteLine("FinalReleaseComObject ref: " + refCounter);
    
                obj = null;
            }
    public void Dispose()
            {
                System.Diagnostics.Debug.WriteLine("In Dispose");
                this.Dispose(false); // because we are doing unmanaged
                GC.Collect();
                GC.SuppressFinalize(this);
            }
    
            protected virtual void Dispose(bool disposing)
            {
                System.Diagnostics.Debug.WriteLine("In Dispose (" + disposing + ")");
                if (!disposing) // unmanaged
                {
                    #region COM Cleanup
    
                    this.DoFinalReleaseCOMObject(this.headerStartCell);
                    this.DoFinalReleaseCOMObject(this.headerEndCell);
                    this.DoFinalReleaseCOMObject(this.headerWriteRange);
    
                    this.DoFinalReleaseCOMObject(this.startCell);
                    this.DoFinalReleaseCOMObject(this.endCell);
                    this.DoFinalReleaseCOMObject(this.writeRange);
    
                    this.DoFinalReleaseCOMObject(this.ws);
                    this.DoFinalReleaseCOMObject(this.wb);
                    this.DoFinalReleaseCOMObject(this.wbs);
    
                    this.DoFinalReleaseCOMObject(this.excelApp);
    
                    System.Diagnostics.Debug.WriteLine("I've tried to clean");
    
                    #endregion
                }
    
                // no need for else condition if dispose is true as we are not dealing with managed objects
            }

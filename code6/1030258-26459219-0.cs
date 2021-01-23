            private bool disposed = false;
           ReportDocument doc=new ReportDocument ();
           ReportDocument rd=new ReportDocument ();
            protected virtual void Dispose(bool disposing)
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        doc.Dispose(); //context means your crystal report document object.
                        rd.Dispose(); 
                    }
                }
                this.disposed = true;
            }
    
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

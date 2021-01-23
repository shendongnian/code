        public class Test : IDisposable
        {
            private bool disposed;
            private PowerShell ps;
            public Test()
            {
                disposed = false;
                ps = PowerShell.Create();
            }
            public void loadModule()
            {
                ps.AddCommand("Add-PSSnapin")
                  .AddParameter("Name", "VMware.VimAutomation.Core")
                  .Invoke();
                if (ps.HadErrors)
                    infoBox.Text = "Error loading snapin";
                else
                    infoBox.Text = "Loaded";
                ps.Commands.Clear();
            }
            public void someOtherMethod()
            {
                //do some more powershell - without loading module
                ps.Commands.Clear();
            }
            public void Dispose()
            {
                Dispose(true);
            }
            private void Dispose(bool disposing)
            {
                if (!disposed)
                {
                    disposed = true;
                    if (disposing)
                    {
                        if (ps != null)
                        {
                            ps.Dispose();
                            ps = null;
                        }
                    }
                }
            }
        }

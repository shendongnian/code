    using System;
    using System.Threading;
    
    namespace uc
    {
        class UserControlViewModel : IDisposable
        {
            Timer timer;
            public UserControlViewModel()
            {
                //Each five seconds check to see if the current user has had their module access permissions changed
                timer = new Timer(CheckUserModuleAccess, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            }
            private void CheckModuleAccess(object state)
            {
                ...
            }
            
            public void Close()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            
            protected virtual void Dispose(bool disposing)
            {
                if (disposing){
                    if (timer != null) {
                        timer.Stop();
                        timer.Dispose();
                        timer = null;
                    }
                }
            }
            
            ~UserControlViewModel()
            {
                Dispose(false);
            }
            
            #region IDisposable Members
            
            void IDisposable.Dispose()
            {
                Close();
            }
            
            #endregion
        }
    }

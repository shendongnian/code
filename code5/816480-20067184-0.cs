        /// <summary>
        /// Call this Method to Destruct all needed Parts safely.
        /// </summary>
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Dispose method
        /// </summary>
        /// <param name="bDisposing"></param>
        protected override void Dispose(bool bDisposing)
        {
            if (!m_bIsDisposed)
            {
                // Method called first time.		
                if (bDisposing)
                {
                    /* Release Managed Objects. If they implement IDisposable, call their Dispose().*/
                    try
                    {
                        // Events, etc.
                    }
                    catch { }
                    this.StopTimer();
                    this.m_Interceptor.Dispose();
                    if (components != null)
                    {
                        components.Dispose();
                    }
                    base.Dispose(bDisposing);
                }
                // Release unmanaged resources (z.B. IntPtr)
		
            }
            // Set it true, so the method doesn't get called again.		
            m_bIsDisposed = true;
        }

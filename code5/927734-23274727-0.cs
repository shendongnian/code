    public void Disconnect()
		{
			// Stop the worker thread.
            if (done != null)
            {
                done.Set();
            }
			// BUG FIX: Simon.Phillips@warwick.ac.uk for UltraVNC disconnect issue
			// Request a tiny screen update to flush the blocking read
			try {
				rfb.WriteFramebufferUpdateRequest(0, 0, 1, 1, false);
			} catch {
				// this may not work, as Disconnect can get called in response to the
				// VncClient raising a ConnectionLost event (e.g., the remote host died).
			}
            if (worker != null)
            {
                worker.Join(3000);	// this number is arbitrary, just so that it doesn't block forever....
            }
			rfb.Close();	
			rfb = null;
		}

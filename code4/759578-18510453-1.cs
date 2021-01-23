	public void application_run(Form form1)
	{
    bool createdNew;
    
    			System.Threading.Mutex m = new System.Threading.Mutex(true, form1.Name, out createdNew);
    			if (!createdNew)
    			{
    				MessageBox.Show("...", "...", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//Alert message
    
    				try
    				{
    					// see if we can find the other app and Bring it to front
    					IntPtr hWnd = FindWindow(null, form1.Text);
    					if (hWnd != IntPtr.Zero)
    					{
    						LoaderDomain.WINDOWPLACEMENT placement = new LoaderDomain.WINDOWPLACEMENT();
    						placement.length = Marshal.SizeOf(placement);
    						GetWindowPlacement(hWnd, ref placement);
    						placement.showCmd = SW_SHOWMAXIMIZED;
    						SetWindowPlacement(hWnd, ref placement);
    						SetForegroundWindow(hWnd);
    					}
    				}
    				catch 
    				{
    					//rien
    				}
    
    			}
    			else
    			{
    				Application.Run(form1);
    			}
    			// keep the mutex reference alive until the normal termination of the program
    			GC.KeepAlive(m);

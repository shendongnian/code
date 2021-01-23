        public bool ShowPropertyPage(Control owner )
        {                      
            object filter = null;
            Guid cat = PinCategory.Capture;
	    Guid med = MediaType.Interleaved; 
	    Guid iid = typeof(IAMStreamConfig).GUID;
	    int hr = graphBuilder.FindInterface( 
	    ref cat, ref med, videoDeviceFilter, ref iid, out filter );
	    if ( hr != 0 )
	    {
		med = MediaType.Video ;
		hr = graphBuilder.FindInterface( 
		ref cat, ref med, videoDeviceFilter, ref iid, out filter );
		if ( hr != 0 )
	        	filter = null;
	     }
            ISpecifyPropertyPages specifyPropertyPages = null;
            DsCAUUID cauuid = new DsCAUUID();
            bool hasPropertyPage = false;
            // Determine if the object supports the interface
            // and has at least 1 property page
            try
            {
                specifyPropertyPages = filter  as ISpecifyPropertyPages;
                if (specifyPropertyPages != null)
                {
                    int hr = specifyPropertyPages.GetPages(out cauuid);
                    if ((hr != 0) || (cauuid.cElems <= 0))
                        specifyPropertyPages = null;
                }
            }
            finally
            {
                if (cauuid.pElems != IntPtr.Zero)
                    Marshal.FreeCoTaskMem(cauuid.pElems);
            }
            // Add the page to the internal collection
            if (specifyPropertyPages != null)
            {
                DirectShowPropertyPage p = new DirectShowPropertyPage(videDevice.Name, specifyPropertyPages);
                p.Show(owner);
                hasPropertyPage = true;
            }
            return (hasPropertyPage);
        }

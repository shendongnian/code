    public IRichEditOle GetRichEditOleInterface()
    {
    	if( this.IRichEditOleValue == null )
    	{
    		// Allocate the ptr that EM_GETOLEINTERFACE will fill in
    		IntPtr ptr = Marshal.AllocCoTaskMem( Marshal.SizeOf( typeof( IntPtr ) ) );  // Alloc the ptr.
    		Marshal.WriteIntPtr( ptr, IntPtr.Zero );                                    // Clear it.
    		try
    		{
    			if( 0 != API.SendMessage( this.Handle, Messages.EM_GETOLEINTERFACE, IntPtr.Zero, ptr ) )
    			{
    				// Read the returned pointer
    				IntPtr pRichEdit = Marshal.ReadIntPtr( ptr );
    				try
    				{
    					if( pRichEdit != IntPtr.Zero )
    					{
    						// Query for the IRichEditOle interface
    						Guid guid = new Guid( "00020D00-0000-0000-c000-000000000046" );
    						Marshal.QueryInterface( pRichEdit, ref guid, out this.IRichEditOlePtr );
    
    						// Wrap it in the C# interface for IRichEditOle
    						this.IRichEditOleValue = (IRichEditOle)Marshal.GetTypedObjectForIUnknown( this.IRichEditOlePtr, typeof( IRichEditOle ) );
    
    						if( this.IRichEditOleValue == null )
    						{
    							throw new Exception( "Failed to get the object wrapper for the IRichEditOle interface." );
    						}
    
    						// IID_ITextDocument
    						guid = new Guid( "8CC497C0-A1DF-11CE-8098-00AA0047BE5D" );
    						Marshal.QueryInterface( pRichEdit, ref guid, out this.ITextDocumentPtr );
    
    						// Wrap it in the C# interface for IRichEditOle
    						this.ITextDocumentValue = (ITextDocument)Marshal.GetTypedObjectForIUnknown( this.ITextDocumentPtr, typeof( ITextDocument ) );
    
    						if( this.ITextDocumentValue == null )
    						{
    							throw new Exception( "Failed to get the object wrapper for the ITextDocument interface." );
    						}
    					}
    					else
    					{
    						throw new Exception( "Failed to get the pointer." );
    					}
    				}
    				finally
    				{
    					Marshal.Release( pRichEdit );
    				}
    			}
    			else
    			{
    				throw new Exception( "EM_GETOLEINTERFACE failed." );
    			}
    		}
    		catch( Exception err )
    		{
    			Trace.WriteLine( err.ToString() );
    			this.ReleaseRichEditOleInterface();
    		}
    		finally
    		{
    			// Free the ptr memory
    			Marshal.FreeCoTaskMem( ptr );
    		}
    	}
    
    	return this.IRichEditOleValue;
    }
	public void ReleaseRichEditOleInterface()
	{
		if( this.IRichEditOlePtr != IntPtr.Zero )
		{
			Marshal.Release( this.IRichEditOlePtr );
		}
		this.IRichEditOlePtr	= IntPtr.Zero;
		this.IRichEditOleValue	= null;
	}

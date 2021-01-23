    // Default token's received aren't impersonation tokens,
    // we are looking for an impersonation token.
    bool isImpersonationToken = false;
    
    // Open the access token of the current process.
    SafeTokenHandle processToken;
    if ( !AdvApi32.OpenProcessToken( ..., out processToken ) )
    {
    	MarshalHelper.ThrowLastWin32ErrorException();
    }
    
    // Starting from Vista linked tokens are supported which need to be checked.
    if ( EnvironmentHelper.VistaOrHigher )
    {
    	// Determine token type: limited, elevated, or default.
    	SafeUnmanagedMemoryHandle elevationTypeHandle = ...;
    	if ( !AdvApi32.GetTokenInformation( ... elevationTypeHandle ) )
    	{
    		MarshalHelper.ThrowLastWin32ErrorException();
    	}
    	var tokenType = (AdvApi32.TokenElevationType)Marshal.ReadInt32( 
            elevationTypeHandle.DangerousGetHandle() );
    
    	// If limited, get the linked elevated token for further check.
    	if ( tokenType == AdvApi32.TokenElevationType.TokenElevationTypeLimited )
    	{
    		// Get the linked token.
    		SafeUnmanagedMemoryHandle linkedTokenHandle = ...;
    		if ( !AdvApi32.GetTokenInformation( ... linkedTokenHandle ) )
    		{
    			MarshalHelper.ThrowLastWin32ErrorException();
    		}
    		processToken = new SafeTokenHandle(
                 Marshal.ReadIntPtr( linkedTokenHandle.DangerousGetHandle() ) );
            // Linked tokens are already impersonation tokens.
    		isImpersonationToken = true;
    	}
    }
    
    // We need an impersonation token in order
    // to check whether it contains admin SID.
    if ( !isImpersonationToken )
    {
    	SafeTokenHandle impersonatedToken;
    	if ( !AdvApi32.DuplicateToken( ..., out impersonatedToken ) )
    	{
    		MarshalHelper.ThrowLastWin32ErrorException();
    	}
    	processToken = impersonatedToken;
    }
    
    // Check if the token to be checked contains admin SID.
    var identity= new WindowsIdentity( processToken.DangerousGetHandle() );
    var principal = new WindowsPrincipal( identity );
    return principal.IsInRole( WindowsBuiltInRole.Administrator );

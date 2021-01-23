    /// <SecurityNote> 
    /// Critical: Calls the native InternetGetCookieEx(). There is potential for information disclosure. 
    /// Safe: A WebPermission demand is made for the given URI.
    /// </SecurityNote> 
    [SecurityCritical, SecurityTreatAsSafe]
    [FriendAccessAllowed] // called by PF.Application.GetCookie()
    [SuppressMessage("Microsoft.Interoperability", "CA1404:CallGetLastErrorImmediatelyAfterPInvoke",
        Justification="It's okay now. Be careful on change.")] 
    internal static string GetCookie(Uri uri, bool throwIfNoCookie)
    { 
        // Always demand in order to prevent any cross-domain information leak. 
        SecurityHelper.DemandWebPermission(uri);
 
        UInt32 size = 0;
        string uriString = BindUriHelper.UriToString(uri);
        if (UnsafeNativeMethods.InternetGetCookieEx(uriString, null, null, ref size, 0, IntPtr.Zero))
        { 
            Debug.Assert(size > 0);
            size++; 
            System.Text.StringBuilder sb = new System.Text.StringBuilder((int)size); 
            // PresentationHost intercepts InternetGetCookieEx(). It will set the INTERNET_COOKIE_THIRD_PARTY
            // flag if necessary. 
            if (UnsafeNativeMethods.InternetGetCookieEx(uriString, null, sb, ref size, 0, IntPtr.Zero))
            {
                return sb.ToString();
            } 
        }
        if (!throwIfNoCookie && Marshal.GetLastWin32Error() == NativeMethods.ERROR_NO_MORE_ITEMS) 
            return null; 
        throw new Win32Exception(/*uses last error code*/);
    }

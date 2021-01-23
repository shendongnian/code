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
    /// <SecurityNote> 
    /// Critical: Sets cookies via the native InternetSetCookieEx(); doesn't demand WebPermission for the given 
    ///     URI. This creates danger of overwriting someone else's cookies.
    ///     The P3P header has to be from an authentic web response in order to be trusted at all. 
    /// </SecurityNote>
    [SecurityCritical]
    private static bool SetCookieUnsafe(Uri uri, string cookieData, string p3pHeader)
    { 
        string uriString = BindUriHelper.UriToString(uri);
        // PresentationHost intercepts InternetSetCookieEx(). It will set the INTERNET_COOKIE_THIRD_PARTY 
        // flag if necessary. (This doesn't look very elegant but is much simpler than having to make the 
        // 3rd party decision here as well or calling into the native code (from PresentationCore).)
        uint res = UnsafeNativeMethods.InternetSetCookieEx( 
            uriString, null, cookieData, UnsafeNativeMethods.INTERNET_COOKIE_EVALUATE_P3P, p3pHeader);
        if(res == 0)
            throw new Win32Exception(/*uses last error code*/);
        return res != UnsafeNativeMethods.COOKIE_STATE_REJECT; 
    }
        private const int MAX_PATH_LENGTH = 2048 ; 
        private const int MAX_SCHEME_LENGTH = 32;
        public const int MAX_URL_LENGTH = MAX_PATH_LENGTH + MAX_SCHEME_LENGTH + 3; /*=sizeof("://")*/ 
        //
        // Uri-toString does 3 things over the standard .toString()
        // 
        //  1) We don't unescape special control characters. The default Uri.ToString()
        //     will unescape a character like ctrl-g, or ctrl-h so the actual char is emitted. 
        //     However it's considered safer to emit the escaped version. 
        //
        //  2) We truncate urls so that they are always <= MAX_URL_LENGTH 
        //
        // This method should be called whenever you are taking a Uri
        // and performing a p-invoke on it.
        // 
        internal static string UriToString(Uri uri)
        { 
            if (uri == null) 
            {
                throw new ArgumentNullException("uri"); 
            }
            return new StringBuilder(
                uri.GetComponents( 
                    uri.IsAbsoluteUri ? UriComponents.AbsoluteUri : UriComponents.SerializationInfoString,
                    UriFormat.SafeUnescaped), 
                MAX_URL_LENGTH).ToString(); 
        }

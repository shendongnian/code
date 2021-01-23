app.Use((context, next) =>
    {
    	context.Response.Headers....;
    	//here decode and replace the cookies
    	return next.Invoke();
    });
 2. using javascript after page load with cookies:
    ```document.cookie = encodeURIComponent(document.cookie);```
 3. or the best way to create extension like this:
        /// <summary>
        ///
        /// </summary>
        public static class CookieExtensions
        {
            /// <summary>
            /// Add a new cookie and value
            ///
            /// </summary>
            /// <param name="header"></param>
            /// <param name="key"/><param name="value"/>
            public static void AppendUrlDecodedCookie(this IHeaderDictionary header, string key, string value)
            {
                header.AppendValues("Set-Cookie", key + "=" + value + "; path=/");
            }
    
            ///  <summary>
            ///  Add a new cookie
            ///
            ///  </summary>
            /// <param name="header"></param>
            /// <param name="key"/><param name="value"/><param name="options"/>
            public static void AppendUrlDecodedCookie(this IHeaderDictionary header, string key, string value, CookieOptions options)
            {
                if (options == null)
                    throw new ArgumentNullException("options");
                bool flag1 = !string.IsNullOrEmpty(options.Domain);
                bool flag2 = !string.IsNullOrEmpty(options.Path);
                bool hasValue = options.Expires.HasValue;
                header.AppendValues("Set-Cookie",
                    key + "=" + (value ?? string.Empty) + (!flag1 ? (string) null : "; domain=") +
                    (!flag1 ? (string) null : options.Domain) + (!flag2 ? (string) null : "; path=") +
                    (!flag2 ? (string) null : options.Path) + (!hasValue ? (string) null : "; expires=") +
                    (!hasValue
                        ? (string) null
                        : options.Expires.Value.ToString("ddd, dd-MMM-yyyy HH:mm:ss ",
                            (IFormatProvider) CultureInfo.InvariantCulture) + "GMT") +
                    (!options.Secure ? (string) null : "; secure") + (!options.HttpOnly ? (string) null : "; HttpOnly"));
            }
        }
And you can use it like this: 
    response.Headers.AppendUrlDecodedCookie("key", "val");
or
    response.Headers.AppendUrlDecodedCookie("key", "val", new Microsoft.Owin.CookieOptions
                                    {
                                        Path = "/",
                                        Domain = ="domain.com",
                                        Expires = Date...
                                    });
And this solve the problem.

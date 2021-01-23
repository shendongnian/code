            using System;
            using System.Collections.Generic;
            using System.ComponentModel;
            using System.Net.Http.Headers;
            using System.Net.Http.Properties;
            using System.Web.Http;
            namespace System.Net.Http
            {
                /// <summary> Provides extension methods for the <see cref="T:System.Net.Http.Headers.HttpResponseHeaders" /> class. </summary>
                [EditorBrowsable(EditorBrowsableState.Never)]
                public static class HttpResponseHeadersExtensions
                {
                    private const string SetCookie = "Set-Cookie";
                    /// <summary> Adds cookies to a response. Each Set-Cookie header is  represented as one <see cref="T:System.Net.Http.Headers.CookieHeaderValue" /> instance. A <see cref="T:System.Net.Http.Headers.CookieHeaderValue" /> contains information about the domain, path, and other cookie information as well as one or more <see cref="T:System.Net.Http.Headers.CookieState" /> instances. Each <see cref="T:System.Net.Http.Headers.CookieState" /> instance contains a cookie name and whatever cookie state is associate with that name. The state is in the form of a  <see cref="T:System.Collections.Specialized.NameValueCollection" /> which on the wire is encoded as HTML Form URL-encoded data.  This representation allows for multiple related "cookies" to be carried within the same Cookie header while still providing separation between each cookie state. A sample Cookie header is shown below. In this example, there are two <see cref="T:System.Net.Http.Headers.CookieState" /> with names state1 and state2 respectively. Further, each cookie state contains two name/value pairs (name1/value1 and name2/value2) and (name3/value3 and name4/value4). &lt;code&gt; Set-Cookie: state1:name1=value1&amp;amp;name2=value2; state2:name3=value3&amp;amp;name4=value4; domain=domain1; path=path1; &lt;/code&gt;</summary>
                    /// <param name="headers">The response headers</param>
                    /// <param name="cookies">The cookie values to add to the response.</param>
                    public static void AddCookies(this HttpResponseHeaders headers, IEnumerable<CookieHeaderValue> cookies)
                    {
                        if (headers == null)
                        {
                            throw Error.ArgumentNull("headers");
                        }
                        if (cookies == null)
                        {
                            throw Error.ArgumentNull("cookies");
                        }
                        foreach (CookieHeaderValue current in cookies)
                        {
                            if (current == null)
                            {
                                throw Error.Argument("cookies", Resources.CookieNull, new object[0]);
                            }
                            headers.TryAddWithoutValidation("Set-Cookie", current.ToString());
                        }
                    }
                }
            }

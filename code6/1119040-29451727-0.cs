            using System;
            using System.Collections.Generic;
            using System.Collections.ObjectModel;
            using System.ComponentModel;
            using System.Linq;
            using System.Net.Http.Headers;
            using System.Web.Http;
            namespace System.Net.Http
            {
                /// <summary>Provides extension methods for the <see cref="T:System.Net.Http.Headers.HttpRequestHeaders" /> class.</summary>
                [EditorBrowsable(EditorBrowsableState.Never)]
                public static class HttpRequestHeadersExtensions
                {
                    private const string Cookie = "Cookie";
                    /// <summary>Gets any cookie headers present in the request.</summary>
                    /// <returns>A collection of <see cref="T:System.Net.Http.Headers.CookieHeaderValue" /> instances.</returns>
                    /// <param name="headers">The request headers.</param>
                    public static Collection<CookieHeaderValue> GetCookies(this HttpRequestHeaders headers)
                    {
                        if (headers == null)
                        {
                            throw Error.ArgumentNull("headers");
                        }
                        Collection<CookieHeaderValue> collection = new Collection<CookieHeaderValue>();
                        IEnumerable<string> enumerable;
                        if (headers.TryGetValues("Cookie", out enumerable))
                        {
                            foreach (string current in enumerable)
                            {
                                CookieHeaderValue item;
                                if (CookieHeaderValue.TryParse(current, out item))
                                {
                                    collection.Add(item);
                                }
                            }
                        }
                        return collection;
                    }
                    /// <summary>Gets any cookie headers present in the request that contain a cookie state whose name that matches the specified value.</summary>
                    /// <returns>A collection of <see cref="T:System.Net.Http.Headers.CookieHeaderValue" /> instances.</returns>
                    /// <param name="headers">The request headers.</param>
                    /// <param name="name">The cookie state name to match.</param>
                    public static Collection<CookieHeaderValue> GetCookies(this HttpRequestHeaders headers, string name)
                    {
                        if (name == null)
                        {
                            throw Error.ArgumentNull("name");
                        }
                        IEnumerable<CookieHeaderValue> cookies = headers.GetCookies();
                        CookieHeaderValue[] list = (
                            from header in cookies
                            where header.Cookies.Any((CookieState state) => string.Equals(state.Name, name, StringComparison.OrdinalIgnoreCase))
                            select header).ToArray<CookieHeaderValue>();
                        return new Collection<CookieHeaderValue>(list);
                    }
                }
            }

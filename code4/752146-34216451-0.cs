	using System;
	using System.Net;
	using System.Runtime.InteropServices;
	using System.Text;
	namespace Sample.Helpers {
		public class NativeMethods {
			public static CookieContainer GetUriCookieContainer(Uri uri) {
				CookieContainer cookies = null;
				int datasize = 8192 * 16; // Determine the size of the cookie
				StringBuilder cookieData = new StringBuilder(datasize);
				if (!InternetGetCookieEx(uri.ToString(), null, cookieData, ref datasize, InternetCookieHttponly, IntPtr.Zero)) {
					if (datasize < 0)
						return null;
					cookieData = new StringBuilder(datasize); // Allocate stringbuilder large enough to hold the cookie
					if (!InternetGetCookieEx(
						uri.ToString(),
						null, cookieData,
						ref datasize,
						InternetCookieHttponly,
						IntPtr.Zero))
						return null;
				}
				if (cookieData.Length > 0) {
					cookies = new CookieContainer();
					cookies.SetCookies(uri, cookieData.ToString().Replace(';', ','));
				}
				return cookies;
			}
			[DllImport("wininet.dll", CharSet = CharSet.Unicode, SetLastError = true, ThrowOnUnmappableChar = true)]
			private static extern bool InternetGetCookieEx(string url, string cookieName, StringBuilder cookieData, ref int size, Int32 dwFlags, IntPtr lpReserved);
			private const Int32 InternetCookieHttponly = 0x2000;
		}
	}

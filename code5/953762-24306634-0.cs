    client.Logout ();
			ClearCookies ();
			await ConnectToMobileService ();
		}
		public static void ClearCookies () {
			Android.Webkit.CookieSyncManager.CreateInstance (Android.App.Application.Context);
			Android.Webkit.CookieManager.Instance.RemoveAllCookie ();
		}

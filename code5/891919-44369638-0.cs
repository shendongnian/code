    WebView webview = FindViewById<WebView>(Resource.Id.webView1);
            video =("the src of the youtube video");
            var uri = Android.Net.Uri.Parse(video);
            WebSettings settings = webview.Settings;
            settings.JavaScriptEnabled = true;
            webview.SetWebChromeClient(new WebChromeClient());
            webview.LoadUrl(video);

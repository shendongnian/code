    private void Start()
    {
        var t = new Thread(ThreadProc);
        t.SetApartmentState(ApartmentState.STA);
        t.Start();
        t.Join();
    }
    public async void ThreadProc()
    {
        try
        {
            var urlBase = "https://JENKINS/";
            var url = urlBase + "job/JOBNAME/api/json?depth=1&tree=lastBuild[timestamp],builds[number,result,timestamp,url,actions[lastBuiltRevision[SHA1,branch[name]],totalCount,failCount,skipCount],building,duration]";
            var form = new Form();
            var browser = new System.Windows.Forms.WebBrowser();
            browser.SetBounds(0, 0, 400, 400);
            form.Size = new System.Drawing.Size(400, 400);
            form.Controls.AddRange(new Control[] { browser });
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            // Navigate to base URL. It should internally forward to login form. After logging in, close browser window.
            browser.Navigate(urlBase);
            form.ShowDialog();
            var cookieString = GetGlobalCookies(urlBase);
            var cookieContainer = new System.Net.CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var client = new HttpClient(handler) { BaseAddress = new Uri(urlBase, UriKind.Absolute) })
            {
                cookieContainer.SetCookies(client.BaseAddress, cookieString);
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var responseStream = await response.Content.ReadAsStreamAsync();
                    using (var reader = new System.IO.StreamReader(responseStream))
                    {
                        var responseString = await reader.ReadToEndAsync();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
    [System.Runtime.InteropServices.DllImport("wininet.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
    private static extern bool InternetGetCookieEx(string pchURL, string pchCookieName,
        System.Text.StringBuilder pchCookieData, ref uint pcchCookieData, int dwFlags, IntPtr lpReserved);
    private const int INTERNET_COOKIE_HTTPONLY = 0x00002000;
    public string GetGlobalCookies(string uri)
    {
        uint uiDataSize = 2048;
        var sbCookieData = new System.Text.StringBuilder((int)uiDataSize);
        if (InternetGetCookieEx(uri, null, sbCookieData, ref uiDataSize,
                INTERNET_COOKIE_HTTPONLY, IntPtr.Zero)
            &&
            sbCookieData.Length > 0)
        {
            return sbCookieData.ToString().Replace(";", ",");
        }
        return null;
    }

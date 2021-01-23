                string cookie = strCookie[0]; // fetch your cookie after logging in
                clientSideTab.Headers.Add("Content-Type","application/json; charset=utf-8");
                clientSideTab.Headers.Add("Accept","application/json");
                clientSideTab.m_container.SetCookies(URI, cookie);
                //clientSideTab.Headers.Add(HttpRequestHeader.Cookie, cookie);
                String resultJSON = clientSideTab.UploadString(URI,"POST", jsonData);

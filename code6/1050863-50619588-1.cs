            private bool isInternetReachable()
            {
                try
                {
                    URL url = new URL("http://www.google.com");
                    HttpURLConnection urlConnect = (HttpURLConnection)url.OpenConnection();
                    Object objData = urlConnect.GetContent(new Class[0]);
                }
                catch (Exception e)
                {
                    return false;
                }
                return true;
            }

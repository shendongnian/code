            if (proxy_list.Count > 0)
            {
            for (int i = 0; i < proxy_list.Count; i++)
            {
                string Proxy = proxy_list[i];
                string[] vars = Proxy.Split( ':' );
                if (vars.Length == 2)
                {
                    proxy = vars[0];
                    port = int.Parse(vars[1]);
                Thread TestProxy = new Thread(testProxy( proxy, port, i));
                TestProxy.Start();
                }
                else
                {
                    proxy_list.RemoveAt(i);
                }
                textBox3.Text = proxy_list.Count.ToString();
                this.Refresh();
            }
        }
        public bool testProxy( string proxy, int port, int listpos )
        {
        try
        {
            WebClient web = new WebClient();
            web.Proxy = new WebProxy( proxy, port);
            web.DownloadString("http://www.google.com/ncr");
            return true;
        }
        catch
        {
            proxy_list.RemoveAt(listpos);
        }
    }

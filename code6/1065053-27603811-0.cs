            using (var webClient = new System.Net.WebClient())
            {
                Stopwatch timer = Stopwatch.StartNew();
                String url = "http://bg2.cba.pl/realmIP.txt";
                timer.Stop();
                TimeSpan timespan = timer.Elapsed;
                String tex1 = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                timer = Stopwatch.StartNew();
                String result = webClient.DownloadString(url); // slow as hell
                timespan = timer.Elapsed;
                String tex2 = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                timer = Stopwatch.StartNew();
                Stream stream = webClient.OpenRead(url);
                timespan = timer.Elapsed;
                String tex3 = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                timer = Stopwatch.StartNew();
                byte[] result2 = new byte[12];
                int val = webClient.OpenRead(url).Read(result2, 0, 12); // even slower
                timespan = timer.Elapsed;
                String tex4 = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);
                textBox1.Text = result;
                t1.Text = tex1;
                t2.Text = tex2;
                t3.Text = tex3;
                t4.Text = tex4;
            }

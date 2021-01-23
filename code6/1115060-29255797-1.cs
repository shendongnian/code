    public void get_html(string add)
            {
                add_val(add);
                Uri madd = new Uri(add);
                Stopwatch timer = Stopwatch.StartNew();
                Task.Factory.StartNew<string>(() => DownloadString(add))
                    .ContinueWith(t => {
                        string html = task.Result;
                        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                        doc.LoadHtml(html);
                        HtmlNode root = doc.DocumentNode; 
                        timer.Stop();
                        TimeSpan timespan = timer.Elapsed;
                        label18.Text = String.Format("{0:00}:{1:00}:{2:00}", timespan.Minutes, timespan.Seconds, timespan.Milliseconds / 10);            
                        //
                        Update UI with results here
                        //
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }

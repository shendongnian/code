    foreach(DataRow row in dt.Rows)
                    {
                        string url = "http://abcd/<userid>?groups=<userid>";
                        var test = url.Replace("<userid>", Convert.ToString(row["UserID"]));
                        System.Diagnostics.Process.Start(url);
                        string client = (new WebClient()).DownloadString("http://abcd/UserID?groups=UserID");
                        if (client.ToLower() == Convert.ToString(TrackID).ToLower())
                        {
                            counter++;
                        }

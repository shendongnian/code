    string baseUrl = "http://some url";
           
            HttpWebRequest request = null;
            using(BlockingCollection<object> bc= new BlockingCollection<object>(20))
            {
            using (Task task1 = Task.Factory.StartNew(() =>
            {
                
                using (SqlConnection connection = new SqlConnection("connectionstring"))
                {
                connection.Open();
                using (SqlCommand cm = new SqlCommand("query", connection))
                {
                    t1.Load(cm.ExecuteReader());
                    foreach (DataRow row in t1.Rows)
                    {
                         fileNames.Add(row["Filename"].ToString());
                         bc.Add(row["Filename"]);
                    }
                    
                    Thread.Sleep(100);
                    Console.WriteLine("This is Add part");
                }
                    
                }
                bc.CompleteAdding();
             }))
                        {
                            using (Task task2 = Task.Factory.StartNew(() =>
                                {
                                        foreach (var item in bc.GetConsumingEnumerable())
                                        {
                                        string url = string.Format(baseUrl, item);
                                        request = (HttpWebRequest)WebRequest.Create(url);
                                        request.Method = "GET";
                                        request.ContentType = "application/x-www-form-urlencoded";
                                        request.CookieContainer = container;
                                        response = (HttpWebResponse)request.GetResponse();
                                        Stream stream = response.GetResponseStream();
                                        img = Image.FromStream(stream);
                                        img.Save("C:\\some path" + item);
                                        //code to create copies of image.
                                        
                                        }
                                        Console.WriteLine("This is Take part");
                                    
                                }))
                                        Task.WaitAll(task1,task2);
                        }
                
                       }
            }

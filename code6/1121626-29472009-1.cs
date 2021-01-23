    List<string> ids = new List<string>();
        HttpWebRequest request =
                        (HttpWebRequest)WebRequest.Create("https://api.guildwars2.com/v2/commerce/listings");
                    try
                    {
                        WebResponse response = request.GetResponse();
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (var reader = new StreamReader(responseStream))
                            {
                                ids = reader.ReadToEnd().TrimStart('[').TrimEnd(']').Split(',').Select(str => str.Trim())
                                    .ToList();
                            }
                        }
                    }
                    catch (Exception)
                    {
                        
                        throw;
                    }
    return ids;

    public string DownloadWebPageData(string url)
        {
            string html = string.Empty;
            try
            {
                using (ConfigurableWebClient client = new ConfigurableWebClient())
                {
                    /* Set timeout for webclient */
                    client.Timeout = 600000;
                    /* Build url */
                    Uri innUri = null;
                    if (!url.StartsWith("http://"))
                        url = "http://" + url;
                    if (url.EndsWith("."))
                        innUri = ManipulateBrokenUrl(url);
                    else
                        Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out innUri);
                    try
                    {
                        client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows; U; Windows NT 5.1; de; rv:1.9.2.3) Gecko/20100401 Firefox/3.6.3 (.NET CLR 3.5.30729) (Prevx 3.0.5)");
                        client.Headers.Add("Vary", "Accept-Encoding");
                        // Specify the encoding for unicode characters
                        client.Encoding = Encoding.UTF8;
                        html = client.DownloadString(innUri);
                        if (string.IsNullOrEmpty(html))
                        {
                            return string.Empty;
                        }
                        else
                        {
                            return html;
                        }
                    }
                    catch (WebException we)
                    {
                        return string.Empty;
                    }
                    catch (Exception ex)
                    {
                        return "";
                    }
                    finally
                    {
                        client.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return null;
        }

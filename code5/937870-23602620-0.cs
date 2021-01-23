    private async void ResponseCallback(IAsyncResult asyncres)
    {
        try
        {
            HttpWebRequest wreq = (HttpWebRequest)asyncres.AsyncState;
            HttpWebResponse wres = (HttpWebResponse)wreq.EndGetResponse(asyncres);
    
            StreamReader sr = new StreamReader(wres.GetResponseStream());
    
            string result = await sr.ReadToEndAsync();
    
            //HTML View
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                HTML.Text = result;
            });
            
    
            //Readable
            string read;
            read = Regex.Replace(result, "<script.*?</script>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            read = Regex.Replace(read, "<style.*?</style>", "", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            read = Regex.Replace(read, "</?[a-z][a-z0-9]*[^<>]*>", "");
            read = Regex.Replace(read, "<!--(.|\\s)*?-->", "");
            read = Regex.Replace(read, "<!(.|\\s)*?>", "");
            read = Regex.Replace(read, "[\t\r\n]", " ");
    
            Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                readable.Text = read;
            });
    
            }
        catch (WebException ex)
        {
            //MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
        }
    }

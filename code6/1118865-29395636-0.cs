         public List<string> GetListMembers(string membersList, string status, string since = "")
        {
            List<string> li = new List<string>();
            //to see what does <dc> means? follow this link https://apidocs.mailchimp.com/api/rtfm/
            string linkPage = @"http://<dc>.api.mailchimp.com/export/1.0/list/?apikey={0}&id={1}&status={2}{3}";
            ListInfo list = mc.GetLists().Data.Where(x => x.Name == membersList).FirstOrDefault();
            linkPage = string.Format(linkPage, conectionMailChimp, list.Id, status, !string.IsNullOrEmpty(since) ? "&since=" + since : string.Empty);
            WebClient wc = new WebClient();
            string text = wc.DownloadString(linkPage);
            text = text.Replace("\"", "");
            string[] res = text.Split(new[] { "]\n[" }, StringSplitOptions.None);
            for (int i = 1; i < res.Length; i++)
                li.Add(res[i].Split(new[] { "," }, StringSplitOptions.None)[0].ToString());
            return li;
        }

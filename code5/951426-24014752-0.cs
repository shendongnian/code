            Uri uri = new Uri(urlbeg + lat + urlmid + lon + urlend, UriKind.Absolute);
              HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(uri);
            //This time, our method is GET.
             WebReq.Method = "GET";
            //From here on, it's all the same as above.
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();
           
            //Now, we read the response (the string), and output it.
            Stream Answer = WebResp.GetResponseStream();
            StreamReader _Answer = new StreamReader(Answer);
            string s = _Answer.ReadToEnd();
          
            XDocument document = XDocument.Parse(s);
             var data1 = from query in document.Descendants("geoname")
                         select new Country
                         {
                             CurrentTime = (string)query.Element("time"),
                         };
             foreach (var d in data1)
             {
                 time = d.CurrentTime;
                 MessageBox.Show(d.CurrentTime);
                 // country = d.CountryName;
             }

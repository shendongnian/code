            XDocument doc = XDocument.Parse(Properties.Resources.videofeed);
            var videos = doc.Descendants().Where(x => x.Name == "video");
            List<LajmeVideo> lajmes = new List<LajmeVideo>();
            foreach (var item in videos)
            {
                var cat = item.Descendants().Where(x => x.Name == "category").FirstOrDefault();
                if (cat.Value == "25" || cat.Value == "99")
                {
                    //addtolist;
                }
                var uri = new Uri("http://www.youtube.com/watch?v=" + item.Descendants().Where(x => x.Name == "youtubeid").FirstOrDefault().Value);
            }

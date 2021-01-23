        public string GenerateMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<nav id=\"nvMenu\" class=\"main-nav\"><ul>");
            sb.Append(PrepareMenuUL(AppConfig._AppConfigInstance.Navigation.FirstOrDefault().NavigationClass));
            sb.Append("</ul></nav>");
            return sb.ToString();
        }
        private string PrepareMenuUL(List<Navigation> navigation)
        {
            StringBuilder sb = new StringBuilder();
            if (Liflag == 1)
            {
                sb.Append("</li>");
                Liflag = 0;
            }
            foreach (var item in navigation)
            {
                var subMenu = item.NavigationClass.Select(b => b as Navigation);
                if (subMenu.Any())
                {
                    sb.Append("<li class=\"dropdown\">");
                    if (subMenu.Any() && item.Url == "#")
                        sb.Append(string.Format("<a href=\"{0}\">{1}<i class=\"icon-arrow\"></i></a>", BaseUrl + item.Url, item.Name));
                    else if (subMenu.Any() && item.Url != "#" && item.Url != null)
                        sb.Append(string.Format("<a href=\"{0}\">{1}<i class=\"icon-rightarrow\"></i></a>", BaseUrl + item.Url, item.Name));
                }
                else
                {
                    sb.Append("<li>");
                    sb.Append(string.Format("<a href=\"{0}\">{1}</a>", BaseUrl + item.Url, item.Name));
                }
                if (subMenu.Any())
                    sb.Append("<ul class=\"wd190\">");
                if (item.NavigationClass.Count > 0)
                {
                    Liflag = 1;
                    sb.Append(PrepareMenuUL(item.NavigationClass));
                }
                sb.Append("</li>");
                if (subMenu.Any())
                    sb.Append("</ul>");
            }
            return sb.ToString();
        }

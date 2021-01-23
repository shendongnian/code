            var postData = new System.Collections.Generic.List<string>();
            var document = new HtmlWeb().Load(url);
            foreach (var input in document.DocumentNode.SelectNodes("//input[@type='hidden']"))
            {
                var name = input.GetAttributeValue("name", "");
                name = Uri.EscapeDataString(name);
                var value = input.GetAttributeValue("value", "");
                value = Uri.EscapeDataString(value);
                if (name == "__EVENTTARGET")
                {
                    value = "btnPageLoad";
                }
                postData.Add(string.Format("{0}={1}", name, value));
            }
            // Use StringBuilder for concatenation 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(postData[0]);
            for (int i = 1; i < postData.Count; i++)
            {
                sb.Append("&");
                sb.Append(postData[i]);
            }
            var postBody = sb.ToString();

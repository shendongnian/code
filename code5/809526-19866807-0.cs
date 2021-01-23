        public void Apply(string selector, Control parent, Action<WebControl> a)
        {
            if (selector.StartsWith("."))
            {
                foreach(WebControl wc in parent.Controls)
                {
                    if (wc.CssClass == selector.Substring(1))
                    {
                        a(wc);
                    }
                }
            }
            if (selector.StartsWith("#"))
            {
                foreach (WebControl wc in parent.Controls)
                {
                    if (wc.ID == selector.Substring(1))
                    {
                        a(wc);
                        return;//no need to search any further.
                    }
                }
            }
        }

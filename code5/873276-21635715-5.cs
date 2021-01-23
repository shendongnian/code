    public static class Extensions
    {
        public static string GetValues(this CheckBoxList list)
        {
            List<string> tmpValues = new List<string>();
            for (int i = 0, ii = list.Items.Count; i < ii; i++)
            {
                if (list.Items[i].Selected)
                    tmpValues.Add(list.Items[i].Value);
            }
            return string.Join("|", tmpValues.ToArray());
        }
        public static void SaveValuesToCookie(this CheckBoxList list, string cookieName)
        {
            string values = list.GetValues();
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookieName, values));
            HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddDays(30);
        }
        public static void CheckItemsFromCookie(this CheckBoxList list, string cookieName)
        {
            //MAKE SURE THE COOKIE EXISTS, IF NOT, THERE IS NOTHING WE CAN DO
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains(cookieName))
                return;
            //MAKE SURE THE COOKIE HAS VALUE AND IT IS NOT NULL
            string value = HttpContext.Current.Request.Cookies[cookieName].Value;
            if (value == null)
                return;
            string[] vals = value.Split('|');
            for (int i = 0, ii = list.Items.Count; i < ii; i++)
                if (vals.Contains(list.Items[i].Value))
                    list.Items[i].Selected = true;
        }
    }

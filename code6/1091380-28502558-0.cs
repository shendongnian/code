       private static ListItem FindUMLogListItem(int serial)
        {
            bool result;
            int endserial, startserial;
            ClientContext clientContext = new ClientContext("http://companyweb");
            List oList = clientContext.Web.Lists.GetByTitle("UM Log");
            CamlQuery camlQuery = new CamlQuery();
            camlQuery.ViewXml = "<View></View>";
            ListItemCollection collListItem = oList.GetItems(camlQuery);
            clientContext.Load(collListItem);
            clientContext.ExecuteQuery();
            foreach (ListItem oListItem in collListItem)
            {
                result = int.TryParse(Regex.Match(oListItem["Title"].ToString(), @"\d+", RegexOptions.IgnorePatternWhitespace).Value, out startserial);
                result = int.TryParse(Regex.Match(oListItem["Ending_x0020_Serial"].ToString(), @"\d+", RegexOptions.IgnorePatternWhitespace).Value, out endserial);
                if ((serial >= startserial) && (serial <= endserial))
                    return oListItem;
            }
            return null;

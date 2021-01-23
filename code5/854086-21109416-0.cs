        public static HtmlTable Table(this HtmlHelper ht, string classe)
        {
            var table = new HtmlTable();
            table.Attributes.Add("class", classe);
            return table;
        }

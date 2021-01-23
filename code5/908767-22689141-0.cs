        private static string ReplaceInsensitive(string text, string oldtext,string newtext)
        {
            int indexof = text.IndexOf(oldtext,0,StringComparison.InvariantCultureIgnoreCase);
            while (indexof != -1)
            {
                text = text.Remove(indexof, oldtext.Length);
                text = text.Insert(indexof, newtext);
                indexof = text.IndexOf(oldtext, indexof + newtext.Length ,StringComparison.InvariantCultureIgnoreCase);
            }
            return text;
        }

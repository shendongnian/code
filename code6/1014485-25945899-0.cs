        string[] GetItems(string htmlText)
        {
            List<string> Answer = new List<string>();
            for (int i = 0; i < htmlText.Length; i++)
            {
                int start = htmlText.IndexOf('>', i);
                i = start;
                int end = htmlText.IndexOf('<', i);
                if (end == -1 || start == -1)
                    break;
                string Item = htmlText.Substring(start + 1, end - start - 1);
                if (Item.Trim() != "")
                    Answer.Add(Item);
                i = end + 1;
            }
            return Answer.ToArray();
        }

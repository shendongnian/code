       public static string PsvQuote(string text)
        {
                  text = String.Format("\"{0}\"", text.Replace("|","").Replace("\r","").Replace("\n","");
                  return text;
        }

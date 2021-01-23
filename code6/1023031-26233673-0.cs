       Class6 c = new Class6();
     var t = s.ToLower().Replace("cola", "##").Split(new char[] { ',', '.', ' ' }).Where(h => h.Contains("##")).Select(h => c.getFistAndLast(h));
      
      public class class6 {
      public string getFistAndLast(string word)
        {
            string[] words = word.Split(new string[] { "##" }, StringSplitOptions.None);
            string h = "";
            if (words[0].Trim() != "")
                h = words[0].Remove(0, words[0].Length - 1)+",";
            if (words[1].Trim() != "")
                h += words[1][0];
            h += " ";
            return h;
        }
       }

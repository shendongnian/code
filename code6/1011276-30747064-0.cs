            string text = "সাজানো";
            var textCharArray = text.ToCharArray();
            var tokens = new List<string>();
            for (int i = 0; i < textCharArray.Length; i++)
            {
                char c = textCharArray[i];
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.SpacingCombiningMark)
                {
                    string token = $"{tokens.Last()}{c}";
                    tokens.RemoveAt(tokens.Count() - 1);
                    tokens.Add(token);
                }
                else
                {
                    tokens.Add($"{c}");
                }
            }
            foreach (string token in tokens) Console.WriteLine(token);

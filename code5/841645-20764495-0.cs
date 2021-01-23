    var input = "I have a listbox in my windows form application that shows quite long texts. Since texts are so long, user have to use the horizontal slider for check the rest of text.\nSo, I want to limit listbox character per line. For every 50 char it should go to next row, so user won't have to use glider.";
    var lines = input.SplitByLength(50).ToList();
---
    public static partial class MyExtensions
    {
        public static  IEnumerable<string> SplitByLength(this string input, int maxLen)
        {
            return Regex.Split(input, @"(.{1," + maxLen + @"})(?:\s|$)")
                        .Where(x => x.Length > 0)
                        .Select(x => x.Trim());
        }
    }

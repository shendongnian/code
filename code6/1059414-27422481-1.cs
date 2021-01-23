    using System.Globalization;
    bool IsPalindrome(string value, StringComparer comparer = null)
    {
        if (s == null)
        {
            throw new ArgumentNullException("value");
        }
        if (comparer == null)
        {
            comparer = StringComparer.CurrentCultureIgnoreCase;
        }
        var elements = new List<string>();
        var m = StringInfo.GetTextElementEnumerator(value);
        while (m.MoveNext())
        {
            elements.Add(m.GetTextElement());
        }
        var i = 0;
        var j = elements.Count - 1;
        var limit = elements.Count / 2;
        for(; i <= limit; i++, j--)
        {
            if (!comparer.Equals(elements[i], elements[j]))
            {
                return false;
            }
        }
        return true;
    }

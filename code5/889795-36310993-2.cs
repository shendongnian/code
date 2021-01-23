    // using System.Globalization;
    
    TextElementEnumerator enumerator =
        StringInfo.GetTextElementEnumerator("Les Mise\u0301rables");
    
    List<string> elements = new List<string>();
    while (enumerator.MoveNext())
        elements.Add(enumerator.GetTextElement());
    
    elements.Reverse();
    string reversed = string.Concat(elements);  // selbarésiM seL

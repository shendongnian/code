     public static IEnumerable<TextRange> GetAllWordRanges(FlowDocument document)
         {
             string pattern = @"[^\W\d](\w|[-']{1,2}(?=\w))*";
             TextPointer pointer = document.ContentStart;
             while (pointer != null)
             {
                 if (pointer.GetPointerContext(LogicalDirection.Forward) == TextPointerContext.Text)
                 {
                     string textRun = pointer.GetTextInRun(LogicalDirection.Forward);
                     MatchCollection matches = Regex.Matches(textRun, pattern);
                     foreach (Match match in matches)
                     {
                         int startIndex = match.Index;
                         int length = match.Length;
                         TextPointer start = pointer.GetPositionAtOffset(startIndex);
                         TextPointer end = start.GetPositionAtOffset(length);
                         yield return new TextRange(start, end);
                     }
                 }
                 pointer = pointer.GetNextContextPosition(LogicalDirection.Forward);
             }
         }

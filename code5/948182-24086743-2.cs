    /// <summary>
    /// Appends text to a range
    /// </summary>
    /// <param name="range">The range to append text to.</param>
    /// <param name="appendText">The text to append.</param>
    /// <param name="appendedRange">The range of the appended text</param>
    /// <returns>
    /// The range of the combined old text and the appended text
    /// </returns>
    private Word.Range AppendToRange(Word.Range range, string appendText, out Word.Range appendedRange)
    {
        // Fetch indexes
        object oldStartPosition = range.Start;           
        object oldEndPosition = range.End;
        object newEndPosition = (int)oldEndPosition + appendText.Length;
            
        // Append the text
        range.InsertAfter(appendText);
         
        // Define the range of the appended text
        appendedRange = Range(ref oldEndPosition, ref newEndPosition);
        // Return the range of the new combined range
        return Range(ref oldStartPosition, ref newEndPosition);
    }

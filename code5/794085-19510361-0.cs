        for (
            TextPointer start = searchRange.Start.GetPositionAtOffset(offset); 
            start != searchRange.End; 
            start = start.GetPositionAtOffset(1))
        {
            var end = start.GetPositionAtOffset(searchText.Length);
            if (end == null) 
            {
                break;
            }
    
            TextRange result = new TextRange(start, end);
    
            if (result.Text.ToLower() == searchText)
            {
               lastOffset = offset;
               return result;
            }
        }
    You have one more similar `for` loop, just add this special check in it too. 

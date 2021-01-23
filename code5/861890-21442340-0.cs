    int curSearchLocation;
    private void FindNext_Click(object sender, RoutedEventArgs e)
    {
        TextRange text = new TextRange(RichEditor.Document.ContentStart, RichEditor.Document.ContentEnd);
        var location = text.Text.IndexOf(SearchBox.Text, curSearchLocation, StringComparison.CurrentCultureIgnoreCase);
        if (location < 0)
        {
            location = text.Text.IndexOf(SearchBox.Text, StringComparison.CurrentCultureIgnoreCase);
        }
        if (location >= 0)
        {
            curSearchLocation = location + 1;
            Select(location, SearchBox.Text.Length);
        }
        else
        {
            curSearchLocation = 0;
            MessageBox.Show("Not found");
        }
        RichEditor.Focus();                                   
    }        
    
    public void Select(int start, int length)
    {
        TextPointer tp = RichEditor.Document.ContentStart;
    
        TextPointer tpLeft = GetPositionAtOffset(tp, start, LogicalDirection.Forward);
        TextPointer tpRight = GetPositionAtOffset(tp, start + length, LogicalDirection.Forward);
        RichEditor.Selection.Select(tpLeft, tpRight);            
    }
    
    private TextPointer GetPositionAtOffset(TextPointer startingPoint, int offset, LogicalDirection direction)
    {
        TextPointer binarySearchPoint1 = null;
        TextPointer binarySearchPoint2 = null;
    
        // setup arguments appropriately
        if (direction == LogicalDirection.Forward)
        {
            binarySearchPoint2 = this.RichEditor.Document.ContentEnd;
    
            if (offset < 0)
            {
                offset = Math.Abs(offset);
            }
        }
    
        if (direction == LogicalDirection.Backward)
        {
            binarySearchPoint2 = this.RichEditor.Document.ContentStart;
    
            if (offset > 0)
            {
                offset = -offset;
            }
        }
    
        // setup for binary search
        bool isFound = false;
        TextPointer resultTextPointer = null;
    
        int offset2 = Math.Abs(GetOffsetInTextLength(startingPoint, binarySearchPoint2));
        int halfOffset = direction == LogicalDirection.Backward ? -(offset2 / 2) : offset2 / 2;
    
        binarySearchPoint1 = startingPoint.GetPositionAtOffset(halfOffset, direction);
        int offset1 = Math.Abs(GetOffsetInTextLength(startingPoint, binarySearchPoint1));
    
        // binary search loop
    
        while (isFound == false)
        {
            if (Math.Abs(offset1) == Math.Abs(offset))
            {
                isFound = true;
                resultTextPointer = binarySearchPoint1;
            }
            else
                if (Math.Abs(offset2) == Math.Abs(offset))
                {
                    isFound = true;
                    resultTextPointer = binarySearchPoint2;
                }
                else
                {
                    if (Math.Abs(offset) < Math.Abs(offset1))
                    {
                        // this is simple case when we search in the 1st half
                        binarySearchPoint2 = binarySearchPoint1;
                        offset2 = offset1;
    
                        halfOffset = direction == LogicalDirection.Backward ? -(offset2 / 2) : offset2 / 2;
    
                        binarySearchPoint1 = startingPoint.GetPositionAtOffset(halfOffset, direction);
                        offset1 = Math.Abs(GetOffsetInTextLength(startingPoint, binarySearchPoint1));
                    }
                    else
                    {
                        // this is more complex case when we search in the 2nd half
                        int rtfOffset1 = startingPoint.GetOffsetToPosition(binarySearchPoint1);
                        int rtfOffset2 = startingPoint.GetOffsetToPosition(binarySearchPoint2);
                        int rtfOffsetMiddle = (Math.Abs(rtfOffset1) + Math.Abs(rtfOffset2)) / 2;
                        if (direction == LogicalDirection.Backward)
                        {
                            rtfOffsetMiddle = -rtfOffsetMiddle;
                        }
    
                        TextPointer binarySearchPointMiddle = startingPoint.GetPositionAtOffset(rtfOffsetMiddle, direction);
                        int offsetMiddle = GetOffsetInTextLength(startingPoint, binarySearchPointMiddle);
    
                        // two cases possible
                        if (Math.Abs(offset) < Math.Abs(offsetMiddle))
                        {
                            // 3rd quarter of search domain
                            binarySearchPoint2 = binarySearchPointMiddle;
                            offset2 = offsetMiddle;
                        }
                        else
                        {
                            // 4th quarter of the search domain
                            binarySearchPoint1 = binarySearchPointMiddle;
                            offset1 = offsetMiddle;
                        }
                    }
                }
        }
    
        return resultTextPointer;
    }
    
    int GetOffsetInTextLength(TextPointer pointer1, TextPointer pointer2)
    {
        if (pointer1 == null || pointer2 == null)
            return 0;
    
        TextRange tr = new TextRange(pointer1, pointer2);
    
        return tr.Text.Length;
    }

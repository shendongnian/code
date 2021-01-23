                if (!isLineSelect)
                {
                    var p = PointToPlace(e.Location);
                    if (e.Clicks == 2)
                    {
                        mouseIsDrag = false; //Here, drag is cancelled. 
                        mouseIsDragDrop = false;
                        draggedRange = null; //Drag range is nullified
                        SelectWord(p); //SelectWord is called to mark the word
                        return;
                    }
                    if (Selection.IsEmpty || !Selection.Contains(p) || this[p.iLine].Count <= p.iChar || ReadOnly)
                        OnMouseClickText(e);
                    else
                    {
                        mouseIsDragDrop = true;
                        mouseIsDrag = false;
                    }
                }

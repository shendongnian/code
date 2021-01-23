                    else if (place != Selection.Start)
                {
                    if (mouseIsWholeWordSelection)
                    {
                        Selection.BeginUpdate();
                        var oldSelection = Selection.Clone();
                        SelectWord(place);
                        if (Selection.End >= mouseIsWholeWordSelectionBaseRange.End)
                        {
                            Selection.Start = (mouseIsWholeWordSelectionBaseRange.Start > Selection.Start) ? mouseIsWholeWordSelectionBaseRange.Start : Selection.Start;
                            Selection.End = mouseIsWholeWordSelectionBaseRange.End;
                        }
                        else if (Selection.Start < mouseIsWholeWordSelectionBaseRange.End)
                        {
                            Selection.Start = new Place(Selection.End.iChar, Selection.End.iLine);
                            Selection.End = mouseIsWholeWordSelectionBaseRange.Start;
                        }
                        Selection.EndUpdate();
                        DoCaretVisible();
                        Invalidate();
                    }
                    else
                    {
                        Place oldEnd = Selection.End;
                        Selection.BeginUpdate();
                        if (Selection.ColumnSelectionMode)
                        {
                            Selection.Start = place;
                            Selection.ColumnSelectionMode = true;
                        }
                        else
                            Selection.Start = place;
                        Selection.End = oldEnd;
                        Selection.EndUpdate();
                        DoCaretVisible();
                        Invalidate();
                    }
                    return;
                }

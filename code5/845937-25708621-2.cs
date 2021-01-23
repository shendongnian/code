                    if (e.Clicks == 2)
                    {
                        //mouseIsDrag = false;
                        mouseIsDragDrop = false;
                        mouseIsWholeWordSelection = true;
                        //draggedRange = null;
                        SelectWord(p);
                        mouseIsWholeWordSelectionBaseRange = Selection.Clone();
                        return;
                    }

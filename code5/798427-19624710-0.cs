                Range range = null;
                object pageBookmark = "TextMarkeEinzelheiten";
                if (_myDoc.Bookmarks.Exists(pageBookmark.ToString()))
                {
                    range = _myDoc.Bookmarks.get_Item(ref pageBookmark).Range;
                    Bookmark bookmark = _myDoc.Bookmarks.get_Item(ref pageBookmark);
                    bookmark.Select();
                }
                else
                {
                    range = range ?? _myDoc.Range(0, 0);
                }
                Word.Paragraph pText = _myDoc.Paragraphs.Add(myRange);

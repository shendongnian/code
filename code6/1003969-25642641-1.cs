        public void cleanBookmark(string bookmark)
        {
            var start = currentDocument.Bookmarks[bookmark].Start;
            var end = currentDocument.Bookmarks[bookmark].End;
            Word.Range range = currentDocument.Range(start, end);
            range.Delete(); 
            //The Delete() only deletes text so if you got tables in the doc it leaves the tables empty. 
            //The following removes the tables in the current range.
            if (range.Tables.Count != 0)
            {
                for (int i = 1; i <= range.Tables.Count; i++)
                {
                    range.Tables[i].Delete();
                }
            }
            currentDocument.Bookmarks.Add(bookmark, range);
        }

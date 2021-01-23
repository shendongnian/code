    public class CSVColumns 
    {
	    public IEnumerable<IList<string>> CSVContents { get; private set; }
	
	    public CSVColumns(IEnumerable<IList<string>> csvcontents)
	    {
		    this.CSVContents = csvcontents;
	    }
        public List<string> FirstNames
        {
            get { return GetColumn("FirstName"); }
        }
        public List<string> LastNames
        {
            get { return GetColumn("LastName"); }
        }
        	
        /// <summary>
        /// Gets a collection of the column data based on the name of the column
        /// from the header row.
        /// </summary>
	    public List<string> GetColumn(string columnname) 
	    {
		    //Get the index of the column with the name
            var firstrow = CSVContents.ElementAtOrDefault(0);
            if (firstrow != null)
            {
                int index = -1;
                foreach (string s in firstrow)
                {
                    index++;
                    if (s == columnname)
                    {
                        return GetColumn(index, true);
                    }
                }
            }
            return new List<string>();
	    }
	
        /// <summary>
        /// Gets all items from a specific column number but skips the
        /// header row if needed.
        /// </summary>
	    public List<string> GetColumn(int index, bool hasHeaderRow = true) 
	    {
            IEnumerable<IList<string>> columns = CSVContents;
            if (hasHeaderRow)
                columns = CSVContents.Skip(1);
            return columns.Select(list =>
                {
                    try
                    {
                        return list[index];
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        return "";
                    }
                }
            ).ToList();
	    }
    }

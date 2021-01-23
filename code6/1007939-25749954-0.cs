    public class Cases : IEnumerable
    {
        private SortedDictionary<string, Reading> cases = new SortedDictionary<string, Reading>(SortBarCodeAscending.Compare);  
        IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
                return cases.GetEnumerator();
        }
		 public bool Add(string caseCode, string scanTime)
		 {
			Reading reading = new Reading(caseCode, scanTime);
			cases.Add(caseCode, reading);   
			//some other logic          
		 }
		private class SortBarCodeAscending: IComparer
		{
		   int IComparer.Compare(object a, object b)
		   {
			  string s1=(string)a;
			  string s2=(string)b;
			  return string.Compare(s1, s2) // you can implement the comparison however you like
		   }
		}	
	}

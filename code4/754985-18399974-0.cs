    public class LinqResults : ObservableCollection<LinqResult> 
    {
        public LinqResults(IEnumerable<LinqResult> linqResults)
        {
            foreach (LinqResult linqResult in linqResults) Add(linqResult);
        }
    }

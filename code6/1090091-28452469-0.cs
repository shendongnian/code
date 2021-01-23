    public class Columns : IEnumerable<Column>
    {
        private List<Column> columnList = new List<Column>;
    
        public void SortByName(List<Column> sortedIncompleteList)
        {
                columnList = sortedIncompleteList.Intersect(columnList)
                                .Concat(columnList.Except(sortedIncompleteList)).ToList();
        }
        //...
    }

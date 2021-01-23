    public class EmployeeComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return string.Compare((EmployeeViewModel)x.Name, (EmployeeViewModel)y.Name);
        }
    }
 
    var view = (ListCollectionView)CollectionViewSource.GetDefaultView(EmployeeCollection);
     view.CustomSort = new EmployeeComparer();

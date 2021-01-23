    internal static class ListHelper
    {
        internal static MyViewModel ConvertToMyViewModel(this IEnumerable<Customer> customers)
        {
            //Assign customers to CustomerList;
            //MyViewModel.CustomerList
            return new MyViewModel();
        }
    }

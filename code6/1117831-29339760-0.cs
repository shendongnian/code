    public class SomeClass
    {
        // private members for those local variables
        private int count;
        private ListBox listOfFinishedOrders;
        public void SomeMethod ()
        {
            // Some code that has `cake`, `listOfFinishedOrders` and `count`
            // as local variables. This is also where the lambda was before.
            // store the values in the type
            this.count = count;
            this.listOfFinishedOrders = listOfFinishedOrders;
            cake.PropertyChanged += CakeChanged;
        }
        private void CakeChanged (object sender, EventArgs e)
        {
            Cake cake = sender as Cake; // sender is the original cake
            // `listOfFinishedOrders` and `count` are instance members
            listOfFinishedOrders.Items.Insert(count, cake.NameOfCake + e.PropertyName);
        }
    }

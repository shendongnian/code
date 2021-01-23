    public class MyList: ListBox
    {
        protected override System.Windows.DependencyObject GetContainerForItemOverride()
        {
            return new MyListBoxItem();
        }
        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is MyListBoxItem;
        }
    }
 

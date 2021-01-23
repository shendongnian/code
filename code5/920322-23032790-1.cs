    public partial class MyListBox: ListBox
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
    public class MyListBoxItem : ListBoxItem
    {
    }
 

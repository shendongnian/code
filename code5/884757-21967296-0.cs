    public class MyListView : ListView
    {
            protected override DependencyObject GetContainerForItemOverride()
            {
                return new ProblemsListItem();
            }
    }

    public class WorkTabsViewModelpublic extends Conductor<IScreen>.Collection.OneActive
    {
        // ....
    
        void CloseAll() {
            foreach (IScreen tab in Items)
            {
                tab.TryClose();
            }
        }
      // ....
    }

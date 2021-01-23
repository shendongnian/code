    namespace System.Windows.Controls
    {
      using System.Linq;
      public static class TreeViewExtensions
      {
        public static void SetExpansion(this TreeView treeView, bool isExpanded) =>
          SetExpansion((ItemsControl)treeView, isExpanded);
        static void SetExpansion(ItemsControl parent, bool isExpanded)
        {
          if (parent is TreeViewItem tvi)
            tvi.IsExpanded = isExpanded;
          if (parent.HasItems)
            foreach (var item in parent.Items.Cast<object>()
          .Select(i => GetTreeViewItem(parent, i, isExpanded)))
              SetExpansion(item, isExpanded);
        }
        static TreeViewItem GetTreeViewItem(
          ItemsControl parent, object item, bool isExpanded)
        {
          if (item is TreeViewItem tvi)
            return tvi;
          var result = ContainerFromItem(parent, item);
          if (result == null && isExpanded)
          {
            parent.UpdateLayout();
            result = ContainerFromItem(parent, item);
          }
          return result;
        }
        static TreeViewItem ContainerFromItem(ItemsControl parent, object item) =>
          (TreeViewItem)parent.ItemContainerGenerator.ContainerFromItem(item);
      }
    }

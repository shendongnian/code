     public class ResourceInstDataTemplateSelector : DataTemplateSelector
     {
         public override DataTemplate
             SelectTemplate(object item, DependencyObject container)
        {
             FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null && item is MyTreeNode)
            {
                MyTreeNode treeNode = item as MyTreeNode;
                DataTemplate temp = null;
                if (treeNode.Failed)
                    temp = App.Current.Resources["failed"] as HierarchicalDataTemplate;                
                else
                    temp = App.Current.Resources["succeded"] as HierarchicalDataTemplate;
                return temp;
            }
            return null;
        }
    }
     
    

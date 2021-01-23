    <local:MyTemplateSelector x:Key="MyTemplateSelector " MyHierarchicalTemplate={StaticResource YOURHIERARCHICALTEMPLATE} MyDataTemplate={StaticResource YOURDATATEMPLATEFORNULLGROUP}/>
    
    <TreeView ItemTemplateSelector={StaticResource MyTemplateSelector}/>
    public class MyTemplateSelector : DataTemplateSelector
    {
        public DataTemplate MyDataTemplate{get;set;}
        public HierarchicalDataTemplate MyHierarchicalTemplate{get;set;}
        public override DataTemplate 
            SelectTemplate(object item, DependencyObject container)
        {
            //Check for null group
            if(NullGroup)
               return MyDataTemplate;
            
            return MyHierarchicalTemplate;
        }
    }

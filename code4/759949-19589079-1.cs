     public class LeafDataTemplateSelector :  DataTemplateSelector
    {
        public override DataTemplate
            SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;
            if (element != null && item != null)
            {
                if (item is InstallationManifesFile)
                    return
                            element.FindResource("FileKey")
                            as DataTemplate;
                else if (item is InstallationManifestHook)
                    return element.FindResource("HookKey")
                            as DataTemplate;
            }
            return null;
        }
    }

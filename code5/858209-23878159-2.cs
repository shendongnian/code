    namespace SilverlightApplication1.Assets
    {
    	public class Utils : DependencyObject
    	{
    		public static readonly DependencyProperty AdditionalResourcesProperty = DependencyProperty.RegisterAttached(
    			"AdditionalResources", typeof(ResourceDictionary), typeof(Utils), new PropertyMetadata(null, OnAdditionalResourcesPropertyChanged));
    
    		public static ResourceDictionary GetAdditionalResources(FrameworkElement obj)
    		{
    			return (ResourceDictionary)obj.GetValue(AdditionalResourcesProperty);
    		}
    
    		public static void SetAdditionalResources(FrameworkElement obj, ResourceDictionary value)
    		{
    			obj.SetValue(AdditionalResourcesProperty, value);
    		}
    
    		private static void OnAdditionalResourcesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    		{
    			FrameworkElement element = d as FrameworkElement;
    			if (element == null)
    				return;
    
    			ResourceDictionary oldValue = e.OldValue as ResourceDictionary;
    			if (oldValue != null)
    			{
    				foreach (DictionaryEntry entry in oldValue)
    				{
    					if (element.Resources.Contains(entry.Key) && element.Resources[entry.Key] == entry.Value)
    						element.Resources.Remove(entry.Key);
    				}
    			}
    
    			ResourceDictionary newValue = e.NewValue as ResourceDictionary;
    			if (newValue != null)
    			{
    				foreach(DictionaryEntry entry in newValue)
    				{
    					element.Resources.Add(entry.Key, entry.Value);
    				}
    			}
    		}
    	}
    }

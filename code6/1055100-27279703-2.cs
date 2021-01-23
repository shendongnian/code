	public class MyTemplateSelector : DataTemplateSelector {
		protected override DataTemplate SelectTemplateCore(object item, DependencyObject container) {
			var contact = (Contact)item;
			
			if (contact.IsOuter == true) {
				return (DataTemplate)Application.Current.Resources["DataTemplate1Name"];
			} else {
				return (DataTemplate)Application.Current.Resources["DataTemplate2Name"];
			}
		}
	}

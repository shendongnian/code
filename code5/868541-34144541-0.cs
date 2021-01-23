	using System;
	using System.Linq;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Markup;
	using System.Collections;
	using System.Windows.Media;
	namespace Utils
	{
		/// <summary>
		/// DataType cannot be null -> define Null type
		/// </summary>
		public class Null
		{
		}
		/// <summary>
		/// Generic template selector selecting the template according to the type
		/// </summary>
		[ContentProperty("Items")]
		public class GenericDataTemplateSelector : DataTemplateSelector
		{
			/// <summary>
			/// Select a template according to the type of the object.
			/// </summary>
			/// <param name="item">The item for which a template shall be selected.</param>
			/// <param name="container">The container, in which the Template shall be used.</param>
			/// <returns>The appropriate template, if found; else null.</returns>
			public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
			{
				DataTemplate defaultTemplate = null;
				if (item != null)
				{
					foreach (var dataTemplate in Items.OfType<DataTemplate>())
					{
						if ((Type)dataTemplate.DataType == null || (Type)dataTemplate.DataType == typeof(Null))
						{
							defaultTemplate = dataTemplate;
						}
						else if (((Type)dataTemplate.DataType).IsInstanceOfType(item))
						{
							return dataTemplate;
						}
					}
				}
				return defaultTemplate;
			}
			/// <summary>
			/// The list of templates.
			/// </summary>
			public IList Items
			{
				get
				{
					if (_items == null)
					{
						_items = new ArrayList();
					}
					return _items;
				}
				set
				{
					Items.Clear();
					foreach (var item in value)
					{
						if (item is DataTemplate)
						{
							_items.Add(item);
						}
					}
				}
			}
			IList _items;
		}
	}

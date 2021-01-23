        using System;
		using System.Collections;
		using System.Collections.Generic;
		using System.ComponentModel;
		using System.Linq;
		using System.Windows;
		using System.Windows.Controls;
		using System.Windows.Data;
		using System.Windows.Markup;
		namespace Adaptors
		{
			[ContentProperty("ComboBox")]
			public class ComboBoxAdaptor : ContentControl
			{
				#region Protected Properties
				protected bool IsChangingSelection
				{get; set;}
				
				protected ICollectionView CollectionView
				{get; set;}
				#endregion
				
				#region Dependency Properties
				public static readonly DependencyProperty ComboBoxProperty = 
					DependencyProperty.Register("ComboBox", typeof(ComboBox), typeof(ComboBoxAdaptor),
					new FrameworkPropertyMetadata(new PropertyChangedCallback(ComboBox_Changed)));
				public ComboBox ComboBox
				{
					get { return (ComboBox)GetValue(ComboBoxProperty);}
					set { SetValue(ComboBoxProperty, value);}
				}
				
				public static readonly DependencyProperty NullItemProperty =
					DependencyProperty.Register("NullItem", typeof(object), typeof(ComboBoxAdaptor),
					new PropertyMetadata("(None)");
				public object NullItem
				{
					get {return GetValue(NullItemProperty);}
					set {SetValue(NullItemProperty, value);}
				}
				
				public static readonly DependencyProperty ItemsSourceProperty =
					DependencyProperty.Register("ItemsSource", typeof(IEnumerable), typeof(ComboBoxAdaptor),
					new FrameworkPropertyMetadata(new PropertyChangedCallback(ItemsSource_Changed)));
				public IEnumerable ItemsSource
				{
					get {return (IEnumerable)GetValue(ItemsSourceProperty);}
					set {SetValue(ItemsSourceProperty, value);}
				}
				
				public static readonly DependencyProperty SelectedItemProperty =
					DependencyProperty.Register("SelectedItem", typeof(object), typeof(ComboBoxAdaptor), 
					new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
					new PropertyChangedCallback(SelectedItem_Changed)));
				public object SelectedItem
				{
					get {return GetValue(SelectedItemProperty);}
					set {SetValue(SelectedItemProperty, value);}
				}
				
				public static readonly DependencyProperty AllowNullProperty =
					DependencyProperty.Register("AllowNull", typeof(bool), typeof(ComboBoxAdaptor),
					new PropertyMetadata(true, AllowNull_Changed));
				public bool AllowNull
				{
					get {return (bool)GetValue(AllowNullProperty);}
					set {SetValue(AllowNullProperty, value);}
				}
				#endregion
				
				#region static PropertyChangedCallbacks
				static void ItemsSource_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
				{
					ComboBoxAdaptor adapter = (ComboBoxAdaptor)d;
					adapter.Adapt();
				}
				
				static void AllowNull_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
				{
					ComboBoxAdaptor adapter = (ComboBoxAdaptor)d;
					adapter.Adapt();
				}
				
				static void SelectedItem_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
				{
					ComboBoxAdaptor adapter = (ComboBoxAdaptor)d;
					if (adapter.ItemsSource != null)
					{
						//If SelectedItem is changing from the Source (which we can tell by checking if the
						//ComboBox.SelectedItem is already set to the new value), trigger Adapt() so that we
						//throw out any items that are not in ItemsSource.
						object adapterValue = (e.NewValue ?? adapter.NullItem);
						object comboboxValue = (adapter.ComboBox.SelectedItem ?? adapter.NullItem);
						if (!object.Equals(adapterValue, comboboxValue))
						{
							adapter.Adapt();
							adapter.ComboBox.SelectedItem = e.NewValue;
						}
						//If the NewValue is not in the CollectionView (and therefore not in the ComboBox)
						//trigger an Adapt so that it will be added.
						else if (e.NewValue != null && !adapter.CollectionView.Contains(e.NewValue))
						{
							adapter.Adapt();
						}
					}
				}
				#endregion
				#region Misc Callbacks
				void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
				{
					if (ComboBox.SelectedItem == NullItem)
					{
						if (!IsChangingSelection)
						{
							IsChangingSelection = true;
							try
							{
								int selectedIndex = ComboBox.SelectedIndex;
								ComboBox.SelectedItem = null;
								ComboBox.SelectedIndex = -1;
								ComboBox.SelectedIndex = selectedIndex;
							}
							finally
							{
								IsChangingSelection = false;
							}
						}
					}
					object newVal = (ComboBox.SelectedItem == null? null: ComboBox.SelectedItem);
					if (!object.Equals(SelectedItem, newVal)
					{
						SelectedItem = newVal;
					}
				}
				
				void CollectionView_CurrentChanged(object sender, EventArgs e)
				{
					if (AllowNull && (ComboBox != null) && (((ICollectionView)sender).CurrentItem == null) && (ComboBox.Items.Count > 0))
					{
						ComboBox.SelectedIndex = 0;
					}
				}
				#endregion
				#region Methods
				protected void Adapt()
				{
					if (CollectionView != null)
					{
						CollectionView.CurrentChanged -= CollectionView_CurrentChanged;
						CollectionView = null;
					}
					if (ComboBox != null && ItemsSource != null)
					{
						CompositeCollection comp = new CompositeCollection();
						//If AllowNull == true, add a "NullItem" as the first item in the ComboBox.
						if (AllowNull)
						{
							comp.Add(NullItem);
						}
						//Now Add the ItemsSource.
						comp.Add(new CollectionContainer{Collection = ItemsSource});
						//Lastly, If Selected item is not null and does not already exist in the ItemsSource,
						//Add it as the last item in the ComboBox
						if (SelectedItem != null)
						{
							List<object> items = ItemsSource.Cast<object>().ToList();
							if (!items.Contains(SelectedItem))
							{
								comp.Add(SelectedItem);
							}
						}
						CollectionView = CollectionViewSource.GetDefaultView(comp);
						if (CollectionView != null)
						{
							CollectionView.CurrentChanged += CollectionView_CurrentChanged;
						}
						ComboBox.ItemsSource = comp
					}
				}
				#endregion
			}
		}

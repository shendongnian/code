    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    using Microsoft.Xaml.Interactivity;
    
    using Windows.Devices.Geolocation;
    using Windows.Foundation;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls.Maps;
    
    namespace Foo.Behaviors
    {
        /// <summary>
        /// Behavior to draw pushpins on a map.  This effectively replaces MapItemsControl, which is flaky as hell.
        /// </summary>
        public class PushpinCollectionBehavior : DependencyObject, IBehavior
        {
            #region IBehavior
    
            public DependencyObject AssociatedObject { get; private set; }
    
            public void Attach(Windows.UI.Xaml.DependencyObject associatedObject)
            {
                var mapControl = associatedObject as MapControl;
    
                if (mapControl == null)
                    throw new ArgumentException("PushpinCollectionBehavior can be attached only to MapControl");
    
                AssociatedObject = associatedObject;
    
                mapControl.Unloaded += MapControlUnloaded;
            }
    
            public void Detach()
            {
                var mapControl = AssociatedObject as MapControl;
    
                if (mapControl != null)
                    mapControl.Unloaded -= MapControlUnloaded;
            }
    
            #endregion
    
            #region Dependency Properties
    
            /// <summary>
            /// The dependency property of the item that contains the pushpin locations.
            /// </summary>
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(object), typeof(PushpinCollectionBehavior), new PropertyMetadata(null, OnItemsSourcePropertyChanged));
    
            /// <summary>
            /// The item that contains the pushpin locations.
            /// </summary>
            public object ItemsSource
            {
                get { return GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
    
            /// <summary>
            /// Adds, moves, or removes the pushpin when the item source changes.
            /// </summary>
            private static void OnItemsSourcePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
            {
                var behavior = dependencyObject as PushpinCollectionBehavior;
                var mapControl = behavior.AssociatedObject as MapControl;
                
                // add the items
    
                if (behavior.ItemsSource is IList)
                    behavior.AddItems(behavior.ItemsSource as IList);
                else
                    throw new Exception("PushpinCollectionBehavior needs an IList as the items source.");
                
                // subscribe to changes in the collection
    
                if (behavior.ItemsSource is INotifyCollectionChanged)
                {
                    var items = behavior.ItemsSource as INotifyCollectionChanged;
                    items.CollectionChanged += behavior.CollectionChanged;
                }
            }
    
            // <summary>
            /// The dependency property of the pushpin template.
            /// </summary>
            public static readonly DependencyProperty ItemTemplateProperty =
                DependencyProperty.Register("ItemTemplate", typeof(DataTemplate), typeof(PushpinCollectionBehavior), new PropertyMetadata(null));
    
            /// <summary>
            /// The pushpin template.
            /// </summary>
            public DataTemplate ItemTemplate
            {
                get { return (DataTemplate)GetValue(ItemTemplateProperty); }
                set { SetValue(ItemTemplateProperty, value); }
            }
    
            #endregion
    
            #region Events
    
            /// <summary>
            /// Adds or removes the items on the map.
            /// </summary>
            private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        AddItems(e.NewItems);
                        break;
    
                    case NotifyCollectionChangedAction.Remove:
                        RemoveItems(e.OldItems);
                        break;
    
                    case NotifyCollectionChangedAction.Reset:
                        ClearItems();
                        break;
                }
            }
    
            /// <summary>
            /// Removes the CollectionChanged event handler from the ItemsSource when the map is unloaded.
            /// </summary>
            void MapControlUnloaded(object sender, RoutedEventArgs e)
            {
                var items = ItemsSource as INotifyCollectionChanged;
    
                if (items != null)
                    items.CollectionChanged -= CollectionChanged;
            }
    
            #endregion
    
            #region Private Functions
    
            /// <summary>
            /// Adds items to the map.
            /// </summary> 
            private void AddItems(IList items)
            {
                var mapControl = AssociatedObject as MapControl;
    
                foreach (var item in items)
                {
                    var templateInstance = ItemTemplate.LoadContent() as FrameworkElement;
    
                    var hashCode = item.GetHashCode();
    
                    templateInstance.Tag = hashCode;
                    templateInstance.DataContext = item;
    
                    mapControl.Children.Add(templateInstance);
    
                    Tags.Add(hashCode);
                }
            }
    
            /// <summary>
            /// Removes items from the map.
            /// </summary>
            private void RemoveItems(IList items)
            {
                var mapControl = AssociatedObject as MapControl;
    
                foreach (var item in items)
                {
                    var hashCode = item.GetHashCode();
    
                    foreach (var child in mapControl.Children.Where(c => c is FrameworkElement))
                    {
                        var frameworkElement = child as FrameworkElement;
    
                        if (hashCode.Equals(frameworkElement.Tag))
                        {
                            mapControl.Children.Remove(frameworkElement);
                            continue;
                        }
                    }
    
                    Tags.Remove(hashCode);
                }
            }
    
            /// <summary>
            /// Clears items from the map.
            /// </summary>
            private void ClearItems()
            {
                var mapControl = AssociatedObject as MapControl;
    
                foreach (var tag in Tags)
                {
                    foreach (var child in mapControl.Children.Where(c => c is FrameworkElement))
                    {
                        var frameworkElement = child as FrameworkElement;
    
                        if (tag.Equals(frameworkElement.Tag))
                        {
                            mapControl.Children.Remove(frameworkElement);
                            continue;
                        }
                    }
                }
    
                Tags.Clear();
            }
    
            #endregion
    
            #region Private Properties
    
            /// <summary>
            /// The object tags of the items this behavior has placed on the map.
            /// </summary>
            private List<int> Tags
            {
                get
                {
                    if (_tags == null)
                        _tags = new List<int>();
    
                    return _tags;
                }
            }
            private List<int> _tags;
    
            #endregion
        }
    }

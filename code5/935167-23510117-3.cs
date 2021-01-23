        using System;
    
    using System.Collections;
    
    using System.Windows.Data;
    
    using System.Windows.Controls;
    
     
    
    namespace System.Windows.Workarounds
    
    {
    
    public static class ListView
    
    {
    
        public static readonly DependencyProperty HasBindableSelectedItemsProperty;
    
        public static readonly DependencyProperty BindableSelectedItemsProperty;
    
        static DependencyProperty SelectionChangedHandlerProperty;
    
     
    
        static ListView()
    
        {
    
        BindableSelectedItemsProperty = DependencyProperty.Register("BindableSelectedItems", typeof(IList),typeof(System.Windows.Controls.ListView));
    
        HasBindableSelectedItemsProperty = DependencyProperty.RegisterAttached("HasBindableSelectedItems", typeof(bool),typeof(System.Windows.Controls.ListView), new PropertyMetadata(false));
    
        SelectionChangedHandlerProperty = DependencyProperty.RegisterAttached("SelectionChangedHandler", typeof(SelectionChangedHandler),typeof(System.Windows.Controls.ListView));
    
        }
    
     
    
        public static void SetHasBindableSelectedItems(System.Windows.Controls.ListView source, bool value)
        {
        SelectionChangedHandler Handler = (SelectionChangedHandler)source.GetValue(SelectionChangedHandlerProperty);
    
        if (value && Handler == null)
        {
            Handler = new SelectionChangedHandler(source);
            source.SetValue(SelectionChangedHandlerProperty, Handler);
        } 
        else if (!value && Handler != null)
        {
            source.ClearValue(SelectionChangedHandlerProperty);
        }
    }
    
    }
    
     
    
    internal class SelectionChangedHandler
    {
    
        Binding Binding;
        internal SelectionChangedHandler(System.Windows.Controls.ListView owner)
        {
            Binding = new Binding("SelectedItems");
            Binding.Source = owner;
            owner.SetBinding(ListView.BindableSelectedItemsProperty, Binding);
            owner.SelectionChanged +=new SelectionChangedEventHandler(Owner_SelectionChanged);
        }
    
        void Owner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Windows.Controls.ListView Owner =(System.Windows.Controls.ListView)sender;
            BindingOperations.ClearBinding(Owner, ListView.BindableSelectedItemsProperty);
            Owner.SetBinding(ListView.BindableSelectedItemsProperty, Binding);
        }
    }
    }

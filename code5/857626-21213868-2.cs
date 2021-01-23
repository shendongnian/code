    using Microsoft.Practices.Prism.ViewModel;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    
    namespace TreeViewSelectTest
    {
        public class TreeNodeVm : NotificationObject
        {
            private TreeNodeVm Parent { get; set; }
    
            private bool _isSelected = false;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    _isSelected = value;
                    RaisePropertyChanged(() => IsSelected);
                }
            }
    
            private bool _isExpanded = false;
            public bool IsExpanded
            {
                get { return _isExpanded; }
                set
                {
                    _isExpanded = value;
                    RaisePropertyChanged(() => IsExpanded);
                }
            }
    
            public ObservableCollection<TreeNodeVm> Children { get; private set; }
    
            public string Header { get; set; }
    
            public TreeNodeVm()
            {
                this.Children = new ObservableCollection<TreeNodeVm>();
                this.Children.CollectionChanged += Children_CollectionChanged;
            }
    
            void Children_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
                {
                    foreach (var newChild in e.NewItems.Cast<TreeNodeVm>())
                    {
                        newChild.Parent = this;
                    }
                }
            }
    
            public TreeNodeVm(string header, IEnumerable<TreeNodeVm> children)
                : this()
            {
                this.Header = header;
                foreach (var child in children)
                    Children.Add(child);
            }
    
            public void MakeVisible()
            {
                if (Parent != null)
                {
                    Parent.MakeVisible();
                }
                this.IsExpanded = true;
            }
    
            public void Select()
            {
                MakeVisible();
    
                this.IsSelected = true;
            }
        }
    }

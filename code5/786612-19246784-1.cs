        class Node<T> : INotifyPropertyChanged // should implement this properly on all properties for binding to work
        {
            public bool IsExpanded { get; set; }
            public bool IsSelected { get; set; }
            public T Value { get; set; }
            public ObservableCollection<Node<T>> Children { get; }
        }
        bool TryFindNode<T>(Node<T> node, T value)
        {
            bool wasFound = false;
            if (Equals(node.Value, value))
            {
                node.IsExpanded = true;
                node.IsSelected = true;
                wasFound = true;
            }
            else
            {
                foreach (var childNode in node.Children)
                {
                    if (SearchNode(childNode, searchText))
                    {
                        node.IsExpanded = true;
                        wasFound = true;
                        break;
                    }
                }
            }
            return wasFound;
        }

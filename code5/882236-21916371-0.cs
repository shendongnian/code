    void RaiseEvent(RoutedEventArgs e) {
        EventRoute route = BuildEventRoute(e);
        RouteNode currentNode = route.Head;
        while (currentNode != null) {
            DependencyObject current = currentNode.Element;
            
            // Update the Source of the RoutedEventArgs (OriginalSource remains the same).
            e.Source = current;
            
            // Invoke class handlers for current node, if any exist.
            foreach (var handler in GetClassHandlers(e)) {
                if (!e.Handled || handler.HandledEventsToo) {
                    handler.Invoke(e);
                }
            }
            
            // Invoke instance handlers for current node, if any exist.
            foreach (var handler in GetInstanceHandlers(e)) {
                if (!e.Handled || handler.HandledEventsToo) {
                    handler.Invoke(e);
                }
            }
            currentNode = currentNode.Next;
            // Continue until we reach the end of the route.
        }
    }

    Entity.Children.AssociationChanged += 
    new CollectionChangeEventHandler(EntityChildrenChanged);
    Entity.Children.Clear();            
    private void EntityChildrenChanged(object sender,
        CollectionChangeEventArgs e)
    {
        // Check for a related reference being removed. 
        if (e.Action == CollectionChangeAction.Remove)
        {
            Context.DeleteObject(e.Element);
        }
    }

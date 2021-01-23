    if (InternalContext.ObjectContext.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
    {
        entry.ChangeState(newState); // just change state
    }
    else
    {
        action(); // invoke ObjectContext.AddObject
    }

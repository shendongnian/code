    public abstract class EntityBase: INotifyPropertyChanged, INotifyPropertyChanging
    {
      ...
      public bool WasUpdated()
      {
        var entry = MyEntities.Context.Entry(this);
        if (entry.State != EntityState.Modified)
          return false;
        bool changed = false;
        foreach (var propName in entry.CurrentValues.PropertyNames)
        {
          changed = changed || (entry.CurrentValues[propName] != entry.OriginalValues[propName]  && !entry.CurrentValues[propName].Equals(entry.OriginalValues[propName]));
          if (changed)
            break;
        }
        return changed;
      }
    }

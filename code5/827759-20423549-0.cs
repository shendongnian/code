    protected override void OnChildChanged(Csla.Core.ChildChangedEventArgs e)
    {
        base.OnChildChanged(e);
        switch (e.PropertyChangedArgs.PropertyName)
        {
            case "IsDefault":
                foreach (ChildObjectType child in this)
                {
                    if (child != e.ChildObject)
                    {
                        child.IsDefault = false;
                    }
                }
                break;
        }
    }

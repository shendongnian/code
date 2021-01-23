    protected override void OnChildChanged(Csla.Core.ChildChangedEventArgs e)
    {
        base.OnChildChanged(e);
        switch (e.PropertyChangedArgs.PropertyName)
        {
            case "IsDefault":
                
                if ( ((ChildObjectType)e.ChildObject).IsDefault == true )
                {
                    // then loop all the other childern 
                    foreach (ChildObjectType child in this)
                    {
                        if (child != e.ChildObject && child.IsDefault == true)
                        {
                            child.IsDefault = false; 
                        }
                    }
                }
                break;
        }
    }

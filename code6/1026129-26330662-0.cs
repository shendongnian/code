    foreach(var item in ContainItems)
    {
        if(item is ContainerItems)
        {
            var containerItems = (ContainerItems)item;
        }
        else
        {
            //Otherwise deal with it as an Items object
        }
    }

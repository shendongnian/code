    ItemsOwner.ItemContainerGenerator.StatusChanged += (s, args) =>
    {
        if (ItemsOwner.ItemContainerGenerator.Status == 
                           GeneratorStatus.ContainersGenerated)
        {
            // Your code goes here.         
        }
    };

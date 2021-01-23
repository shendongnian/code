       var destinationPropertyCollectionAsThings = 
           thisDestinationPropertyCollection.Cast<BaseThing>();
    
        foreach (BaseThing thing in sourcePropertyCollectionAsThings)
        {
            thing.UpdateOrCreateThing(destinationPropertyCollectionAsThings);
        }

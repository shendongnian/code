    public static IEnumerable<TargetObject> GetRecursively(TargetObject startingObject) 
    {
        yield return startingObject;
        if (startingObject.InnerObjects != null)
            foreach (TargetObject innerObject in startingObject.InnerObjects.ToArray())
                foreach (TargetObject recursiveInner in GetRecursively(innerObject))
                    yield return recursiveInner;
    }

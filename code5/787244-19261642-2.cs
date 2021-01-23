    public static IEnumerable<TargetObject> GetRecursively2(params TargetObject[] startingObjects)
    {
        foreach (TargetObject startingObject in startingObjects)
        {
            yield return startingObject;
            if (startingObject.InnerObjects != null)
                foreach (TargetObject innerObject in startingObject.InnerObjects.ToArray())
                    foreach (TargetObject recursiveInner in GetRecursively(innerObject))
                        yield return recursiveInner;
        }
    }

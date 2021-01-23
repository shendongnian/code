    public static int? GetDegreeOfRelationship(Type typeA, Type typeB)
    {
        if (typeA.IsInterface || typeB.IsInterface) return null; // interfaces are not part of the inheritance tree
        if (typeA == typeB) return 0;
        int distance = 0;
        Type child;
        if (typeA.IsAssignableFrom(typeB))
        {
            child = typeB;
            while ((child = child.BaseType) != typeA)
                distance--;
            return --distance;
        }
        else if(typeB.IsAssignableFrom(typeA))
        {
            child = typeA;
            while ((child = child.BaseType) != typeB)
                distance++;
            return ++distance;
        }
        else
           return null;
    }

    [Invoke(HasSideEffects = true)]
    public void UpdateCol3OfAllEntitiesWithIds(int[] ids)
    {
        // Use you data access layer to perform the neccessary
        // query: "UPDATE MyTab SET col3 = 'X' WHERE id IN (...)"...
    }

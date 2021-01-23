    public List<T> GetAbandonCodes<T>() where T : class
    {
        List<T> ab;
        using (DataWarehouseEntities context = new DataWarehouseEntities())
        {
            ab = context.Set<T>().ToList();
        }
        return ab;
    }

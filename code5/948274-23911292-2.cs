    public static TEntity Move<TEntity, T>(this TEntity entity, IMover<T> mover) where TEntity : IMovable<TEntity, T> where T : struct
    {
        entity.MoveTo(mover);
        return entity;
    }

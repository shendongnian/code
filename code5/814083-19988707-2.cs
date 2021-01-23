    public static IQueryable<D> ReturnDTO<E, D>(this IQueryable<E> query,
                                     IQueryable<BaseObjectWithDTO<D, int>> dummy)
    // now you can do...
    myQueryable.ReturnDTO(myQueryable);
    // instead of 
    myQueryable.ReturnDTO<BaseObjectWithDTO<BaseDTO, int>, BaseDTO>();

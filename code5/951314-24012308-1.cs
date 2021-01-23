    public static ValidatedResult<TResult> ValidatedHandle<TQuery, TResult>(
        this IQueryHandler<TQuery, TResult> handler,
        TQuery query, ModelStateDictionary modelState)
    {
        try
        {
            return new ValidatedResult<TResult>.CreateValid(handler.Handle(query));
        }
        catch (ValidationException ex)
        {
            modelState.AddModelErrors(ex);
            return ValidatedResult<TResult>.Invalid;
        }
    }

    <td>@item.TicketRef.NullSafe(s => s.Substring(0, 5))...</td>
    public static TResult NullSafe<TObj, TResult>(
    	this TObj obj, 
    	Func<TObj, TResult> func, 
    	TResult ifNullReturn = default(TResult))
    {
    	return obj != null ? func(obj) : ifNullReturn;
    }

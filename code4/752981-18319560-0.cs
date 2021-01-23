    static class ResultExtension 
    {
    	public static Status GetStatus<T>(this Result res, T a) {
    		return res.Failed? new Status{Failed=a.GetType().ToString()} : null;
    	}
    }

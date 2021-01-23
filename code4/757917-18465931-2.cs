    public DataColumn this[int index]
    {
	    get
	    {
		    DataColumn result;
		    try
		    {
			    result = (DataColumn)this._list[index];
		    }
		    catch (ArgumentOutOfRangeException)
		    {
			    throw ExceptionBuilder.ColumnOutOfRange(index);
		    }
		    return result;
	    }
    }

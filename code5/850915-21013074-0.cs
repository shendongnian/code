    void ICollection.CopyTo(Array array, int arrayIndex)
    {
    	if (array != null && array.Rank != 1)
    	{
    		ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_RankMultiDimNotSupported);
    	}
    	try
    	{
    		Array.Copy(this._items, 0, array, arrayIndex, this._size);
    	}
    	catch (ArrayTypeMismatchException)
    	{
    		ThrowHelper.ThrowArgumentException(ExceptionResource.Argument_InvalidArrayType);
    	}
    }

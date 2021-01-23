    private void CopyTo(KeyValuePair<TKey, TValue>[] array, int index)
    {
      if (array == null)
        ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
      if (index < 0 || index > array.Length)
        ThrowHelper.ThrowArgumentOutOfRangeException(ExceptionArgument.index, ExceptionResource.ArgumentOutOfRange_NeedNonNegNum);
      if (array.Length - index < this.Count)
        ThrowHelper.ThrowArgumentException(ExceptionResource.Arg_ArrayPlusOffTooSmall);
      int num = this.count;
      Dictionary<TKey, TValue>.Entry[] entryArray = this.entries;
      for (int index1 = 0; index1 < num; ++index1)
      {
        if (entryArray[index1].hashCode >= 0)
          array[index++] = new KeyValuePair<TKey, TValue>(entryArray[index1].key, entryArray[index1].value);
      }
    }

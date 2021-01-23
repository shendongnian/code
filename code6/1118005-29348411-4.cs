    public void TestIndex1(int index)
    {
      if(index < 0 || index >= _size)
        ThrowHelper.ThrowArgumentOutOfRangeException();
    }
    public void TestIndex2(int index)
    {
      if((uint)index >= (uint)_size)
        ThrowHelper.ThrowArgumentOutOfRangeException();
    }

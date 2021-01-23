	internal int NewRecordFromArray(object[] value)
	{
		int count = this.columnCollection.Count;
		if (count < value.Length)
		{
			throw ExceptionBuilder.ValueArrayLength();
		}
		int num = this.recordManager.NewRecordBase();
		int result;
		try
		{
			for (int i = 0; i < value.Length; i++)
			{
				if (value[i] != null)
				{
					this.columnCollection[i][num] = value[i];
				}
				else
				{
					this.columnCollection[i].Init(num);
				}
			}
			for (int j = value.Length; j < count; j++)
			{
				this.columnCollection[j].Init(num);
			}
			result = num;
		}
		catch (Exception e)
		{
			if (ADP.IsCatchableOrSecurityExceptionType(e))
			{
				this.FreeRecord(ref num);
			}
			throw;
		}
		return result;
	}

    public class SomeClass
	{
		public int a0 = 1;
		public int a1 = 2;
		public int a2 = 3;
		public void DoSomething()
		{
			int result = 1;
			for (int index = 0; index < 3; index++)
			{
				string fieldName = "a" + index;
				var field = typeof(SomeClass).GetField(fieldName);
				int fieldValue = (int)field.GetValue(this);
				result *= fieldValue;
			}
			Debug.Assert(result == 6);
		}
    }

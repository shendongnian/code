    static IEnumerable<T[]> CombinationsAnyLength<T>(params T[] values)
	{
		Stack<int> stack = new Stack<int>(values.Length);
		int i = 0;
		while (stack.Count > 0 || i < values.Length) {
			if (i < values.Length) {
				stack.Push(i++);
				int c = stack.Count;
				T[] result = new T[c];
				foreach (var index in stack) result[--c] = values[index];
				yield return result;
			} else {
				i = stack.Pop() + 1;
				if (stack.Count > 0) i = stack.Pop() + 1;
			}
		}
	}
    CombinationsAnyLength(1, 2, 3, 4) outputs:

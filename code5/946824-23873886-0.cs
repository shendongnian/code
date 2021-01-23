        public class SortComparer : IComparer<Test>
		{
			public int Compare(Test x, Test y)
			{
				if (x.Sort == y.Sort) {
					return 0;
				}
				if (x.Sort == Sort.First){
					return -1;
				}
				if (x.Sort == Sort.Second && y.Sort==Sort.First){
					return 1;
				}
				if (x.Sort == Sort.Second && y.Sort==Sort.Third){
					return -1;
				}
				return 0;
			}
		}

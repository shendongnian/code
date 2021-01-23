	public class Macierz : DependencyObject
	{
		public Macierz(int A, int B)
		{
			this.A = A;
			this.B = B;
			for (int i = 0; i < A; i++)
			{
				for (int j = 0; j < B; j++)
				{
					M.Add(new BigInteger(i, j));
				}
			}
		}
		//A Dependency Property
		public int A
		{
			get { return (int)GetValue(AProperty); }
			private set { SetValue(AProperty, value); }
		}
		public static readonly DependencyProperty AProperty =
			DependencyProperty.Register("A", typeof(int), typeof(Macierz), new UIPropertyMetadata(0));
		//B Dependency Property
		public int B
		{
			get { return (int)GetValue(BProperty); }
			private set { SetValue(BProperty, value); }
		}
		public static readonly DependencyProperty BProperty =
			DependencyProperty.Register("B", typeof(int), typeof(Macierz), new UIPropertyMetadata(0));
		//Rows Observable Collection
		public ObservableCollection<BigInteger> M { get { return _m; } }
		private ObservableCollection<BigInteger> _m = new ObservableCollection<BigInteger>();
		public BigInteger this[int i, int j]
		{
			get { return M[i * B + j]; }
			set { M[i * B + j] = value; }
		}
	}

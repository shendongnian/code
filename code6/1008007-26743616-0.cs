		struct IntWrapper
		{
			readonly int x;
			
			public IntWrapper(int x)
			{
				this.x = x;
			}
			
			//[MethodImpl(MethodImplOptions.AggressiveInlining)] doesn't seem to matter
			public static implicit operator IntWrapper(int x)
			{
				return new IntWrapper(x);
			}
			
			//[MethodImpl(MethodImplOptions.AggressiveInlining)] doesn't seem to matter
			public static IntWrapper operator +(IntWrapper x, IntWrapper y)
			{
				return new IntWrapper(x.x + y.x);
			}
		}
		void Main()
		{
			var random = new Random();
			var sw = new Stopwatch();
			var xs = new List<int>(500);
			var mode = new Dictionary<int, int>();
			
			for (var j = 0; j < 500; j++)
			{
				sw.Start();
				
				for (var i = 0; i < 1000000; i++)
				{
					var x = random.Next();
					var y = random.Next();
					
					var z = x + y;
				}
				
				sw.Stop();
				
				var elasped = (int)sw.ElapsedMilliseconds;
				
				xs.Add(elasped);
				
				int count;
				
				if(!mode.TryGetValue(elasped, out count))
					mode.Add(elasped, 1);
				else
					mode[elasped] = count + 1;
				
				Console.WriteLine(elasped);
				
				sw.Reset();
			}
			
			Console.WriteLine(xs.Average());
			Console.WriteLine(Math.Sqrt(xs.Select(x => Math.Pow(x, 2)).Sum() / (xs.Count())));
			
			var max = 0;
			var key = 0;
			
			foreach (var memo in mode)
				if(memo.Value > max)
				{
					max = memo.Value;
					key = memo.Key;
				}
				
			Console.WriteLine(key);
			
		}
		

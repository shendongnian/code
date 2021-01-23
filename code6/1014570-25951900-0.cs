	using System;
	using System.Linq;
	namespace ConsoleApplication1
	{
		class Program
		{
			static void Main(string[] args)
			{
				var records = new[] {
									new Records{ID=100,ListNum=1,Value=2,Score=10},
									new Records{ID=300,ListNum=1,Value=2,Score=9},
									new Records{ID=200,ListNum=1,Value=4,Score=11},
									new Records{ID=100,ListNum=2,Value=3,Score=10.5},
									new Records{ID=200,ListNum=2,Value=3,Score=10}
								   };
				var idScoreSumDictionary = records
								 .GroupBy(rec => rec.ID)
								 .ToDictionary(
									 rec => rec.Key, 
									 rec => rec.Sum(x => x.Score)
								 );
			}
		}
		class Records
		{
			public int ID { get; set; }
			public int ListNum { get; set; }
			public int Value { get; set; }
			public double Score { get; set; }
		}
	}

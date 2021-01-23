    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace main
    {
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter your number");
			Int64 x = Convert.ToInt64(Console.ReadLine());
			Int64 y, j, i, k, z = x;
			x = x + 5;
		loop:
			x++;
			for (i = 0, y = x; y != 0; i++)
				y /= 10;
			for (j = x, k = i; k != 0; j /= 10, k--)
			{
				if (j % 10 != 9)
					if (j % 10 != 0)
						goto loop;
			}
			if (x % z != 0)
				goto loop;
			Console.WriteLine("answer:{0}",x);
			Console.ReadKey();
		}
	}
    }

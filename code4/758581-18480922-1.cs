	using System;
	using System.Runtime.CompilerServices;
	namespace NewTest
	{
		class ProgramA
		{
			static void Main(string[] args)
			{
				TakeRam(1200000000, 1000000);
			}
			[MethodImpl(MethodImplOptions.NoOptimization)]
			static public void TakeRam(long X, int Y)
			{
				Byte[] byteArray = new Byte[X];
				for (int i = 0; i < X; ++i)
					byteArray[i] = 99;
				System.Threading.Thread.Sleep(Y);
			}
		}
	}

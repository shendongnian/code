    using System;
    
    class DeltaTimeExample
	{
		static void Main(string[] args)
		{
			DateTime time1 = DateTime.Now;
			DateTime time2 = DateTime.Now;
			// Here we find DeltaTime in while loop
			while (true)
			{
				// This is it, use it where you want, it is time between
				// two iterations of while loop
				time2 = DateTime.Now;
				float deltaTime = (time2.Ticks - time1.Ticks) / 10000000f; 
				Console.WriteLine(deltaTime);  // *float* output {0,2493331}
				Console.WriteLine(time2.Ticks - time1.Ticks); // *int* output {2493331}
				time1 = time2;
			}
		}
	}

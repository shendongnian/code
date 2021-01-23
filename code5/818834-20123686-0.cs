    namespace ConsoleApplication1
    {
	class Program
	{
		static void Main(string[] args)
		{
			string[] list = new string[] { "A", "B", "C", "D" };
			List<string> combined = new List<string>();
			for (int i = 0; i < list.Length; i++)
			{
				combined.Add(list[i]);
				for (int j = 0; j < list.Length; j++)
				{
					combined.Add(list[i] + list[j]);
					for (int k = 0; k < list.Length; k++)
					{
						combined.Add(list[i] + list[j] + list[k]);
						for (int l = 0; l < list.Length; l++)
						{
							combined.Add(list[i]+list[j] + list[k] + list[l]);
						}
					}
				}
			}
			combined.ForEach(item => Console.WriteLine(item));
			Console.ReadKey();
		}
	}
}

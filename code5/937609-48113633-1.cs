	int temp = 0;
	int[] arr = new int[] { 5, 6, 2, 4, 1 };
	for (int i = 0; i <= arr.Length - 1; i++)
	{
		for (int j = i + 1; j <= arr.Length - 1; j++)
		{
			if (arr[i] > arr[j])     //> Asecnding Order < Desending Order
			{
				temp = arr[i];
				arr[i] = arr[j];
				arr[j] = temp;
			}
		}
		Console.Write(arr[i]);
	}
	Console.ReadLine();

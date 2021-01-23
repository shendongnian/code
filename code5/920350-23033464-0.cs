	public static int[] MakePie(int n)
      {
        double pi = Math.PI;
        var str = pi.ToString().Remove(1, 1);
		var chararray = str.ToCharArray();
        var numbers = new int[n];
        for (int i = 0; i < n; i++)
		{
			numbers[i] = int.Parse(chararray[i].ToString());
        }
        return numbers;
    }

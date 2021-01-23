        int[] numbers = new int[args.Length];
        int temp;
        for(int i=0;i<args.Length;i++)
        {
            if (Int32.TryParse(args[i],out temp))
            {
                numbers[i] = temp;
            }
            else
            {
                numbers[i] = 0;
            }
         }

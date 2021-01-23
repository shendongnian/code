        const int count = 78;
        if (dic.ContainsKey(count))
        {
            Console.WriteLine(dic[count]);
        }
        else
        {
            Console.WriteLine("The dictionary does not contain the key: {0}", count);
        }
      

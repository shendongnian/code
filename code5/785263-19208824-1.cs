    using (System.IO.StreamWriter file = new System.IO.StreamWriter("D:\\test.txt"))
    {
        for (int i = 0; i < 500; i++)
        {
            file.WriteLine(i);
        }
    }

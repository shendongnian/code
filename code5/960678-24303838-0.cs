    for (int z1 = 0; z1 <= z; z1++)
    {
        for (int c = 0; c < m.Length; c++)
        {
            for (int x = 0; x < 4; x++)
            {
                if(matrix[z1,c,x]!=0)
                {
                    File.AppendAllText("matrix.txt",z1+" "+c+" "+x+" "+matrix[z1,c,x]+System.Environment.NewLine)//NewLine to isolate each matrix value on a different line
                }
            }
        }
    }

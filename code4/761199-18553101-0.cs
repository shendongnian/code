        byte[] byt = File.ReadAllBytes("D:\\a.exe");
        for (int i = 0; i <= byt.Length - 1; i++)
        {
            if (byt[i] == 80)
            {
                if (byt[i + 1] == 75)
                {
                    if (byt[i + 2] == 3)
                    {
                        if (byt[i + 3] == 4)
                        {
                            byt[i] = 66;
                            byt[i + 1] = 76;
                            byt[i + 2] = 3;
                            byt[i + 3] = 4;
                        }
                    }
                        
                }
            }
        }
        File.WriteAllBytes("D:\\b.exe", byt);

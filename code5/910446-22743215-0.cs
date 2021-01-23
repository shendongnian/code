       int i = 0;
       while ((line = enemies.ReadLine()) != null)
       {
            string[] items = line.Split('\t');
            for (int i2 = 0; i2 < items.Length; i2++)
            {
                Console.WriteLine(i2);
                enemyInfo[i, i2] = items[i2];
                Console.WriteLine("[{0},{1}] = {2}", i, i2, enemyInfo[i, i2]);
                Console.ReadLine();
            }
            i++;
       }

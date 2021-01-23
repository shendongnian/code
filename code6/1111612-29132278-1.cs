     for (i = 3; i < 13; i++)
     {
          if(x + 2 <= M.Length)
          {
              data[i + 1] = Convert.ToByte((M.Substring(x, 2)), 16);
              x += 2;
          }
      }

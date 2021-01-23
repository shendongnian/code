     for (i = 3; i < 13; i++)
         {
              if(x + 8 <= M.Length)
              {
                  data[i + 1] = Convert.ToByte((M.Substring(x, 8)), 2);
                  x += 8;
              }
          }

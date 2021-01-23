      public static bool IsValidDate(string date)
      {
          Regex pattern = new Regex(“^\\d{4}/\\d{2}/\\d{2}$”);
          Regex[] arrPattern = new Regex[] {
              new Regex(“^\\d{4}/\\d{2}/\\d{2}$”),
              new Regex(“^\\d{4}/\\d{2}/\\d{1}$”),
              new Regex(“^\\d{4}/\\d{1}/\\d{2}$”),
              new Regex(“^\\d{4}/\\d{1}/\\d{1}$”),
              new Regex(“^\\d{2}/\\d{2}/\\d{2}$”),
              new Regex(“^\\d{2}/\\d{2}/\\d{1}$”),
              new Regex(“^\\d{2}/\\d{1}/\\d{2}$”),
              new Regex(“^\\d{2}/\\d{1}/\\d{1}”)
          };
          int kabise = 1387;
          int year = 0;
          int mounth = 0;
          int day = 0; bool flag = false;
          for (int i = 0; i < arrPattern.Length; i++)
          {
              if (arrPattern[i].IsMatch(date))
                  flag = true;
          }
          if (flag == false) return flag;
          //جدا کننده تاریخ می تواند یکی از این کاراکترها باشد
          string[] splitDate = date.Split(‘/’,‘-’,‘:’);
          year = Convert.ToInt32(splitDate[0]);
          mounth = Convert.ToInt32(splitDate[1]);
          day = Convert.ToInt32(splitDate[2]);
          if (mounth > 12 || mounth <= 0)
              flag = false;
          else
          {
              if (mounth < 7)
              {
                  if (day > 31)
                  {
                      flag = false;
                  }
              }
              if (mounth == 12)
              {
                  int t = (year – kabise) % 4;
                  if ((year – kabise) % 4 == 0)
                  {
                      if (day >= 31)
                          flag = false;
                  }
                  else if (day >= 30)
                      flag = false;
              }
              else
              {
                  if (day > 30)
                      flag = false;
              }
          }
          return flag;
      }

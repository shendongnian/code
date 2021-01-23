    switch (type)
          {
            case 0:
              return Days.Sunday.ToString();
            case 1:
              return Days.Monday.ToString();
            case 2:
              return Days.Tuesday.ToString();
            case 3:
              return Days.Wednesday.ToString();
            case 4:
              return Days.Thursday.ToString();
            case 5:
              return Days.Friday.ToString();
            case 6:
              return Days.Saturday.ToString();
            default:
              return string.Empty;
           }

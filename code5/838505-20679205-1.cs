    var ordered2 = list.OrderBy(foo =>
        {
           switch (foo.Status)
           {
                  case (int)Status.Normal:
                        return 0;
                  case (int)Status.Aged:
                        return 1;
                  case (int)Status.Empty:
                        return 2;
                  case (int)Status.Dead:
                        return 3;
                  default:
                        return 0;
           }
        }).ToList();

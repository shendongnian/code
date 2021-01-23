    List<DateTime> dateLlist = new List<DateTime>();
            dateLlist.Add(new DateTime(2014, 1, 1, 1, 0, 0, 0));
            dateLlist.Add(new DateTime(2014, 1, 1, 1, 10, 0, 0));
            dateLlist.Add(new DateTime(2014, 1, 1, 1, 45, 0, 0));
            DateTime previousTime = new DateTime();
            bool shouldAdd = false;
            List<DateTime> newList = dateLlist.Where(x =>
            {
                shouldAdd = (previousTime == DateTime.MinValue || previousTime.AddMinutes(30) < x);
                previousTime = x;
                return shouldAdd;
            }).ToList();  

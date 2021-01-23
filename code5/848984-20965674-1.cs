     DataTable dtSource = new DataTable();
            dtSource.Columns.Add("Sunday");
            dtSource.Columns.Add("Monday");
            dtSource.Columns.Add("Tuesday");
            dtSource.Columns.Add("Wednesday");
            dtSource.Columns.Add("Thursday");
            dtSource.Columns.Add("Friday");
            dtSource.Columns.Add("Saturday");
          
             int year = 1995;
            int month = 3;
            int DaysInMonth = DateTime.DaysInMonth(year, month);
            int i = 1;
            for (int weak = 0; weak <= 5; weak++)
            {
                DataRow newday = dtSource.NewRow();
                for (int day = 1; day <= 7; day++)
                {
                    if (i > DaysInMonth) break;
                     DateTime dDate = DateTime.Parse(i.ToString() + "/" + month .ToString()+ "/" + year.ToString());
                    DayOfWeek dayWeek = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(dDate);
                    newday[dayWeek.ToString()] = i.ToString();
                    i++;
                    if (dayWeek.ToString() == "Saturday") break;
                }
                dtSource.Rows.Add(newday);
                if (i > DaysInMonth) break;
            }
            WeekRepeater.DataSource = dtSource;
            WeekRepeater.DataBind();

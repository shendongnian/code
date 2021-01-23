            DateTime start = new DateTime(2014, 4, 24);
            DateTime end = new DateTime(2014, 4, 22);
            DateTime current = start < end ? start : end;
            DateTime stop = start < end ? end : start;
            List<DateTime> dates = new List<DateTime>();
            while (current <= stop)
            {
                dates.Add(current);
                current = current.AddDays(1);
            }
            StringBuilder sb = new StringBuilder();
            foreach (DateTime dt in dates)
            {
                if (sb.Length > 0)
                    sb.Append("|");
                sb.Append(dt.ToString("dd/MM/yyyy"));
            }
            Console.WriteLine(sb.ToString());

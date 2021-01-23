      This is your code... Try.. 
   
            int days = 0;
            DateTime deyt = DateTime.Now;
            DateTime dt = deyt.AddDays(int.Parse(textBox3.Text));
            DateTime span = deyt;
            while (span <= dt)
            {
                if (span.DayOfWeek != DayOfWeek.Saturday && span.DayOfWeek != DayOfWeek.Sunday)
                {
                    days++;
                    bd.Text = days.ToString();
                    Console.WriteLine(span.ToString("MM/dd/yy"));
                }
                span = span.AddDays(1);
            }

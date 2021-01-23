    class CurrentRentWeek
    {
        private DateTime cRentWeekStart;
        private DateTime cRentWeekEnd;
        private DateTime today = DateTime.Now;
        public string DateCheck(string rentWeek)
        {
            if (today.DayOfWeek == DayOfWeek.Thursday)
            {
                cRentWeekStart = today.AddDays(-5);
                cRentWeekEnd = today.AddDays(2);
                rentWeek = "Current Rent Week: " + cRentWeekStart.ToString("dd/MM/yyyy") + " - " + cRentWeekEnd.ToString("dd/MM/yyyy");
            }
            else
            {
                rentWeek = "";
            }
            return rentWeek;
        }
    }

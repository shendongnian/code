        private DateTime MatlabToNET(double days)
        {
            return new DateTime(1, 1, 1).AddDays(days).AddYears(-1);
        }
        private double NETtoMatlab(DateTime dt)
        {
            TimeSpan ts = dt - new DateTime();
            return ts.TotalDays + 365;
        }

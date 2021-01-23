     //Constructor 
        public FullTimeEmployee(string FFName, string FLName, double FID, double FHours)
        {
            FEmployeeFName = FFName;
            FEmployeeLName = FLName;
            FEmployeeID = FID; // This was backwards in your code.
            FEmployeeWorkHour = FHours;
            RegPay = calcRegPay(); // You need this line and the next one...
            OTPay = CalOTPay(); // to trigger your payment calculations.
        }

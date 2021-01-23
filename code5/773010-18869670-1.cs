     string[] separotrs = { ",", "\r" };
     string[] result= aurdino.Split(separotrs, StringSplitOptions.RemoveEmptyEntries);
           double batteryVoltage = Convert.ToDouble(result[1]); //Sorry if order is incorrect:-)
           double v0 = Convert.ToDouble(result[0]);
           double I = Convert.ToDouble(result[2]);

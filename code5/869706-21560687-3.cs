            const decimal d = 123.45m; 
            const decimal d1 = 0.123m;
            const decimal d2 = .567m;
            const decimal d3 = .333m;
            const decimal d4 = -123.45m;
    
            NumberFormatInfo currentProvider = NumberFormatInfo.InvariantInfo;
            var newProvider = (NumberFormatInfo) currentProvider.Clone();
            newProvider.NumberDecimalDigits = 0;
            string number = d.ToString("N", newProvider);  //returns 123 =  .Length = 3
            string number1 = d1.ToString("N", newProvider); //returns 0 = .Length = 1
            string number2 = d2.ToString("N", newProvider); //returns 1 =  .Length = 1
            string number3 = d3.ToString("N", newProvider); //returns 0 =  .Length = 1
            string number4 = Math.Abs(d4).ToString("N", newProvider); //returns 123 =  .Length = 3

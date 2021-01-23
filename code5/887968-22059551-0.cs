    using System.Globalization;
 
    NumberFormatInfo info = new NumberFormatInfo();
            info.NumberGroupSizes = new int[] { 3, 2 };
            int number = 12345678;
            string Result = number.ToString("#,#", info);

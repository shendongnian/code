    enum Colors { Red = 1, Green = 2, Blue = 4, Yellow = 8 };
    string colorName = "Blue";
    if (Enum.IsDefined(typeof(Colors), colorName))  //true
     {
         Colors clr = (Colors)Enum.Parse(typeof(Colors), colorName);
     }
     colorName = "Orange";
     if (Enum.IsDefined(typeof(Colors), colorName)) //false
     {
          Colors clr = (Colors)Enum.Parse(typeof(Colors), colorName);
     }

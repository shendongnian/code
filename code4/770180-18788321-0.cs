    string str = "Jan van Rijswijcklaan 124";
    var array = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    string streetname = "";
    string streetnumber = "";
    foreach (var item in array)
    {
         if (Char.IsNumber(item[0]))
             streetnumber += item;
          else
             streetname += item + " ";
    }
    Console.WriteLine(streetname.TrimEnd());
    Console.WriteLine(streetnumber);

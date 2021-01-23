    if (contactNo.Length != 10)
    {
        Console.WriteLine("The length of the Contact No. is not 10");       
    }
    else
    {
        long contactLong;
        if (Int64.TryParse(ContactNo, out contactLong)
        {
            return true;
        }
        else
        {
            Console.WriteLine("Given string does not represent a number");
        }
    }
    return false;

    while (inputValid != true)
    { 
        userBirthdate = DateTime.Parse(Console.ReadLine());
     
        if (userBirthdate > todayDate)
        {
            Console.Write("Invalid Date.  Please enter your date of birth (dd/mm/yy):  ");
        }
        else
        {
            Console.WriteLine(userBirthdate);
            inputValid = true;
        }
    }

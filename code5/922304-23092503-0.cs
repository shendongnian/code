        using System;
    
        namespace AgeAfterTenYears
        {
        class AgeAfterTenYears
        {
        static void Main()
        {
            var age = 0;
            Console.WriteLine("Enter birthdate - DD/MM/YYYY");
            string birthdate = Console.ReadLine();
            DateTime bd = Convert.ToDateTime(birthdate);
            DateTime curDate = DateTime.Today;
            if (bd > curDate)
            {
                Console.WriteLine("Birthdate must be equal to or before today");
            }
            else
            {
                age = curDate.Year - bd.Year;
            }
            if (bd.Month > curDate.Month)
            {
               age = --set your age here//curDate.Year - bd.Year
            }
            Console.WriteLine("You are: {0} years old", age);
        }
    
    }

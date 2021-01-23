    class Program
    {
        static void Main(string[] args)
        {
            //Gives date of birth
            DateTime dob = new DateTime(1989, 10, 30, 23, 31, 00);
            //Gives current age
            DateTime today = DateTime.Today;
            int age = today.Year -dob.Year;
            if (today < dob.AddYears(age)) age--;
            //age plus ten years
            age = age +10;
            Console.WriteLine(age);
            Console.ReadLine();
        }
    }

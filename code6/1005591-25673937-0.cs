        private static void ContainsTest()
        {
            string input = "<a class=";
            string test = "<a class=\"doctor\" href=\"/public-register/doctor-details.aspx?view=1&id=%2082358\">Aal Ali, Saleh Saif Salem A S Fares </a>(#82358)";
            Console.WriteLine("test Contains input: "+test.Contains(input).ToString());
        }

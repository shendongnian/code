            try
            {
                DateTime dt = DateTime.Parse(Console.ReadLine());
                int month = dt.Month;
                string datetime = dt.ToShortDateString();
                // Do Whatever You Want With The String
                .
                .
                .
                .
            }
            catch (Exception)
            {
                Console.WriteLine("EORROR. Incorrect DateTime Format ...");
                // Now You Must Change dd/mm/yyyy to mm/dd/yyyy
                .
                .
                .
                .
            }

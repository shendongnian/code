        public Boolean SaveInfo(String firstName, String lastName, DateTime dateOfBirth,
    String email, String streetAddress, String suburb, String state, int postcode)
        {
            string text = firstName + " " + lastName + " " + dateOfBirth + " " + email + " " + streetAddress + " " + suburb + " " + state + " " + postcode + " ";
            String[] people = Regex.Split(text, " ");
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("Person.txt", true))
                {
                    foreach (string c in people)
                    {
                        file.Write(c);
                    }
                    file.Close();
                }
                return true;
            }
            catch (Exception)
            {
                return  false;
            }
        }

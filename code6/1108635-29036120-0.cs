        static void Main(string[] args)
        {
            string doctorName = "Dr. Vee";
            string patientName = "Mrs. Park";
            string doctorName2 = "Dr. Longer";
            string patientName2 = "Mr. Ranker";
            Console.WriteLine(GetFinalString(doctorName, patientName));
            Console.WriteLine(GetFinalString(doctorName2, patientName2));
            Console.ReadLine();
        }
        private static string GetFinalString(string doctorName, string patientName)
        {
            int targetPatientLocation = 15;
            int length = doctorName.ToCharArray().Count();
            int targetPatientSpaces = targetPatientLocation - length;
            string final = doctorName;
            for (int i = 0; i < targetPatientSpaces; i++)
            {
                final += " ";
            }
            final += patientName;
            return final;
        }

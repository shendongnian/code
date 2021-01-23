    FileStream fStream = new FileStream("Students.txt", FileMode.Open, FileAccess.Read);
    StreamReader inFile = new StreamReader(fStream);
    string inValue;
    string[] values;
    double GPA;
    double total = 0;
    double counter = 0;
    double count = 0;
    double counti = 0;
    double countNoTelephone = 0;
    List<string> Anderson = new List<string>(); //Anderson
    List<string> gpa = new List<string>(); //GPA
    List<string> noemail = new List<string>(); // email
    while (!inFile.EndOfStream)
    {
        inValue = inFile.ReadLine();
        if (inValue.StartsWith("(LIST (LIST "))
        {
            values = inValue.Split(" ".ToCharArray());
            GPA = double.Parse(values[8]);
            total = total + GPA;
            counter++;
            if (values[2] == "'Anderson")
            {
                Anderson.Add(values[2]);
                count++;
            }
            if (values[2] == " ")
            {
                counter++;
            }
            if (values[7] == "'NONE") // you got this off by one
            {
                noemail.Add(values[6]);
                counti++;
            }
            if (values[6] == "'NONE") // you are not counting this
            {
                countNoTelephone++;
            }
        }
    }
    double average = total / counter;
    Console.WriteLine("The average gpa is..." + average);
    Console.WriteLine("Total last names with Anderson is..." + count);
    Console.WriteLine("Total number of students is..." + counter);
    Console.WriteLine("Total with no emails is..." + counti);
    Console.WriteLine("Total with no telephone is..." + countNoTelephone);
    Console.WriteLine("Total with no telephone or emails are..." + (countNoTelephone + counti)); // add both no telephone and no emails together
    Console.ReadKey();

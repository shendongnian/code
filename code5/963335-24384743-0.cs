     using (StreamWriter sw = new StreamWriter("C:/Projects/data/PYAEGON1AEGONRESULT.csv"))
     using (StreamReader sr = new StreamReader("C:/Projects/data/PYAEGON1AEGON.csv"))
     {
         sr.ReadLine();
         // the next ReadLine will read the second line as desired
         heading = "Title, First Name, Surname, Date Of Birth, NI Number,    Gender, Payroll Reference, Address Line 1, Address Line 2, Address Line 3, Address Line 4, AddressLine 5, PostCode, Country, Email, Date Joined Employer, Annual Pensionable Salary, Current Period All Earnings (Monthly), Current Period Pensionable Earnings (Monthly), Emnployee (Amount Deducted), Employer (Amount Deducted), Leaving Date.";
         sw.WriteLine(heading);
         while((txtline = sr.ReadLine()) != null)
         {
             // ...
             sw.WriteLine(csvline);
             // ...

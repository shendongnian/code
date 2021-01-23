     StreamReader readData = new StreamReader(@"c:\Users\1484814\desktop\date.txt");
     DataTable listOFDates = new DataTable();
     listOFDates.Columns.Add("Dates", typeof(DateTime));
     listOFDates.Columns.Add("Numbers", typeof(int));
     while (!readData.EndOfStream)
     {
         string line = readData.ReadLine();
         string[] parts = line.Split(' ');
         DateTime dt = DateTime.ParseExact(string.Join(" ", parts[0], parts[1]), "dd/MM/yyyy hh:mm", CultureInfo.CurrentCulture, DateTimeStyles.None);
         int number = Convert.ToInt32(Regex.Match(parts[2], @"\d+").Value);
         listOFDates.Rows.Add(new object[] {dt, number});
     }
     gv_textFile.DataSource = listOFDates;

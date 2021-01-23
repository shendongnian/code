    int counter = 0;
    string line;
    string[] words;
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\test.txt");
    while((line = file.ReadLine()) != null)
    {
       words = line.Split("|", StringSplitOptions.RemoveEmptyEntries);
       string userlogintimePart = words[2];
       DateTime loginDate = Convert.ToDate(userlogintimePart.Substring(0, "Userlogintime:".Length));
       if (loginDate > DateTime.Now.AddDays(-1))
          counter++;
       //This is a simple example, but almost everithing in it what you need
       //continue withadd the username into a key value pair
       //if you find again you increment the value by one
    }
    file.Close();
    Console.WriteLine("{0} member logged in from yestoday", counter);

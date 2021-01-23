    var teenager = new TeenagerPerson("Joanne", new DateTime(2000, 11, 05));
    teenager.BestFriendForever = new TeenagerPerson("Julia", new DateTime(2000, 10, 05));
    Console.WriteLine(teenager.DisplayData());
    var adult = new AdultPerson("Mike", new DateTime(1960, 01, 03));
    adult.HealthRecord = "2003 - Heart Bypass";
    Console.WriteLine(adult.DisplayData());

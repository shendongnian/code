    File.ReadAllLines(@"Template.txt").Select(line =>
    {
      var items = line.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
      var names = item[1].Split(' ');
      return new {
         AccountId = items[0],
         FirstName = names[0],
         LastName = names[1],
         Address = items[2]
      };
    });

    int intDuplicateCriteria = 2; //Any grade duplicated by a value greater than 2 
    int[] lstGrades = new[] { 80, 81, 90, 90, 90, 100, 85, 86, 86, 79, 95, 95, 95 };
    var lstDuplicate = lstGrades
                     .GroupBy(grade => grade)
                     .Where(g => g.Count() > intDuplicateCriteria)
                     .Select(g => g.Key);
    //Display consecutively grades given 3 times
    foreach (var d in lstDuplicate)
        {
          Console.WriteLine(d.ToString());               
        }

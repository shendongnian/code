      List<string> students = new List<string> { "Peter", "Lisa", "A", "B", "C", "F", "J", "K" };
      Random rng = new Random();
      List<List<string>> studentGroupList = new List<List<string>>();
      List<string> currentGroupList = new List<string>();
      int groupNumber = 0;
      int groupSize = 4;
      while (students.Count > 0)
      {
        string thisStudent = students[rng.Next(students.Count)];
        currentGroupList.Add(thisStudent);
        students.Remove(thisStudent);
        if (groupSize == currentGroupList.Count || students.Count == 0)
        {
          groupNumber++;
          studentGroupList.Add(currentGroupList);
          currentGroupList = new List<string>();
        }
      }
      // this iterates over all lists in studentGroupList,
      // then over all students in the current list and prints them;
      // it separates the printed groups by empty lines
      foreach (List<string> group in studentGroupList)
      {
        foreach (string student in group)
        {
          Console.WriteLine(student);
        }
        Console.WriteLine();
      }
      Console.ReadKey();

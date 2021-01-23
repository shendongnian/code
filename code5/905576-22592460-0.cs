    private static void displayDepartments(University u)
    {
        foreach (Department d in u.Departments)
        {
              if (d.students.count == 0)
              {
              Console.WriteLine(d.name.ToString());
              }
              else
              {
              Console.WriteLine("All departments contain students");
              }
        }
}

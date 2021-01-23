    public class DepartmentViewModel
    {
      public ObservableCollection<Person> People {get; set; }
      public int NewPeopleCount
      {
        get
        {
          return People.Where(p => p.New).Count();
        }
      }
    }

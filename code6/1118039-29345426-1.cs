	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<Employee> demo = new List<Employee>
			                      {
				                      new Employee{Name = "Frank", WorkDays = new List<WorkDay>
				                                                            {
					                                                            new WorkDay{Date = new DateTime(2001,1,2), Hours = 8},
																				new WorkDay{Date = new DateTime(2001,1,3), Hours = 7},
				                                                            }},
								      new Employee{Name = "Herbert", WorkDays = new List<WorkDay>
				                                                            {
					                                                            new WorkDay{Date = new DateTime(2001,1,2), Hours = 8},
																				new WorkDay{Date = new DateTime(2001,1,4), Hours = 7},
				                                                            }}
			                      };
			pivotTarget.DataContext = PivotWorkingHours(demo);
		}
		private DataTable PivotWorkingHours(IEnumerable<Employee> employees)
		{
			DataTable result = new DataTable();
			result.Columns.Add("Date", typeof(DateTime));
			foreach (string name in employees.Select(x => x.Name).Distinct())
			{
				result.Columns.Add(name, typeof(int));
			}
			foreach (DateTime date in employees.SelectMany(e => e.WorkDays.Select(wd => wd.Date)).Distinct())
			{
				DataRow row = result.NewRow();
				row["Date"] = date;
				foreach (Employee employee in employees)
				{
					row[employee.Name] = employee.WorkDays.Where(wd => wd.Date == date).Sum(wd => wd.Hours);
				}
				result.Rows.Add(row);
			}
			return result;
		}
	}
	class Employee
	{
		public String Name { get; set; }
		public List<WorkDay> WorkDays { get; set; }
	}
	class WorkDay
	{
		public DateTime Date { get; set; }
		public int Hours { get; set; }
	}

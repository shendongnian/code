	 public class Student
		{
			string firstname;
			string lastname;
			public Student(string pFirstName, string pLastName)
			{
				firstname = pFirstName;
				lastname = pLastName;
			}
			public string Firstname
			{
				get { return firstname; }
				set { firstname = value; }
			}
			
			public string Lastname
			{
				get { return lastname; }
				set { lastname = value; }
			}
		}

    public static void Main()
	{
		var context = new Context();
		var staff = new Staff() { Id = Guid.NewGuid() };
		var contact = new Contact();
		contact.Id = Guid.NewGuid();
		contact.Name = "Hello DotFiddle!";
		staff.ContactId = contact.Id;
		context.Staffs.Add(staff);
		
		Console.WriteLine("staff contact is null: " + (staff.Contact == null).ToString());
		
		context.Contacts.Add(contact);
		Console.WriteLine("staff contact is null: " + (staff.Contact == null).ToString());
		
		Console.WriteLine("Staff.Contact.Name: "+ staff.Contact.Name);
	}

	public class Person : ICustomTypeDescriptor 
	{
		public string Name { get; set; }
		public int Age { get; set; }
		/* ... Unimplemented ICustomTypeDescriptor methods left out ... */
		public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
		{
			PropertyDescriptor[] propertyDescriptors = new PropertyDescriptor[]
														{
															new MyPropertyDescriptor<Person, string>("My Name", p => p.Name, (p, s) => p.Name = s), 
															new MyPropertyDescriptor<Person, int>("My Age", p => p.Age, (p, i) => p.Age = i)
														};
			return new PropertyDescriptorCollection(propertyDescriptors);
		}
	}

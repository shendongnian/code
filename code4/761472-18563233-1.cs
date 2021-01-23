        public class ComboBoxValues : System.Collections.ObjectModel.Collection<ComboBoxValue>
		{
			public ComboBoxValues()
			{
				this.Add(new ComboBoxValue
				{
					Name = "chad",
					Id = 123,
					Status = "one"
				});
				this.Add(new ComboBoxValue
				{
					Name = "different chad",
					Id = 123,
					Status = "two"
				});
			}
		}
		public class ComboBoxValue
		{
			public string Name { get; set; }
			public int Id { get; set; }
			public string Status { get; set; }
		}

    			Parent p = new Parent();
			p.Children.Add(new Child()
			{
				Parent = p,
				Index = 0
			});
			p.Children.Add(new Child()
			{
				Parent = p,
				Index = 1
			});
			using (var file = File.Create("graph.bin"))
			{
				Serializer.Serialize(file, p);
			}
			Parent newPerson;
			using (var file = File.OpenRead("graph.bin"))
			{
				newPerson = Serializer.Deserialize<Parent>(file);
			}

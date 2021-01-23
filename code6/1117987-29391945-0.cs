    Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund", Region = "Texas" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams", Region = "NY" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss", Region = "Texas" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff", Region = "Corolado" };
            Person rui = new Person { FirstName = "Rui", LastName = "Raposo", Region = "Texas" };
            Person phyllis = new Person { FirstName = "Phyllis", LastName = "Harris", Region = "California" };
            Pet barley = new Pet { Name = "Barley", Owner = terry, State = "NY" };
            Pet boots = new Pet { Name = "Boots", Owner = terry, State = "New Jersey" };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte, State = "Texas" };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus, State = "NY" };
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene, rui, phyllis };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, daisy };
            var petsGroupQuery = (from pet in pets
                                  group pet by pet.State into petGroup
                                  select new Container { Key = petGroup.Key, Pets = petGroup.Select(x => x).ToList(), People = new  List<Person> ()}).Union
                                  (from pep in people
                                   group pep by pep.Region into pepGroup
                                   select new Container { Key = pepGroup.Key, Pets = new List<Pet>(), People = pepGroup.Select(x => x).ToList() }).GroupBy
                                   (x => x.Key)
                                   .Select(t => new Container {Key = t.Key, People = t.SelectMany(x => x.People), Pets = t.SelectMany(x => x.Pets) });
            //// printing
            petsGroupQuery.ToList().ForEach(x =>
                {
                    Trace.WriteLine(x.Key);
                    Trace.WriteLine(string.Join(",", x.People.Select(t => t.FirstName)));
                    Trace.WriteLine(string.Join(",", x.Pets.Select(t => t.Name)));
                });

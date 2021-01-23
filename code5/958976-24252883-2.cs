    static void Main(string[] args)
        {
            using (var db = new FooDb())
            {
                List<Foo> foos = new List<Foo>(){
                    new BarTypeA ("peanutsA"){ DisplayOrder=100,Package="packA"},
                    new BarTypeA ("olivesA"){ DisplayOrder = 101,Package="packB" },
                    new BarTypeB ("peanutsB"){ DisplayOrder = 200,Package="packC" },
                    new BarTypeB ("olivesB"){ DisplayOrder = 201,Package="packD" },
                    new BarTypeC ("peanutsC"){ DisplayOrder = 300,Package="packE" },
                    new BarTypeC ("olivesC"){ DisplayOrder = 301,Package="packF" }
                };
                db.BarTypesA.Add((BarTypeA)foos[0]);
                db.BarTypesA.Add((BarTypeA)foos[1]);
                db.BarTypesB.Add((BarTypeB)foos[2]);
                db.BarTypesB.Add((BarTypeB)foos[3]);
                db.BarTypesC.Add((BarTypeC)foos[4]);
                db.BarTypesC.Add((BarTypeC)foos[5]);
                db.SaveChanges();
            }
            Console.WriteLine("Press any key to end");
            Console.ReadLine();
        }

    var list = new List<TestObject>
                           {
                               new TestObject { Field1 = 1, Field2 = 10, Stringfield = "Object1" },
                               new TestObject { Field1 = 1, Field2 = 10, Stringfield = "Object2" },
                               new TestObject { Field1 = 1, Field2 = 10, Stringfield = "Object3" },
                               new TestObject { Field1 = 1, Field2 = 10, Stringfield = "Object4" },
                               new TestObject { Field1 = 1, Field2 = 10, Stringfield = "Object5" }
                           };
            var subtotal = 0m;
            list.ForEach(x => x.SubTotalField = subtotal += x.Field1);
            Console.WriteLine("Object\tF1\tF2\tTotal");
            foreach (var testObject in list)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", testObject.Stringfield, testObject.Field1, testObject.Field2, testObject.SubTotalField);
            }

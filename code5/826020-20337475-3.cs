                var myClass = new MyClass2()
                {
                    ID = 0,
                    Objects = new List<MyBaseClass>()
                    {
                        new MyBaseClass()
                        {
                            Name = "Object 1"
                        },
                        new MyBaseClass()
                        {
                            Name = "Object 2"
                        }
                    }
                };
                db.Classes.Add( myClass );
                db.SaveChanges();

                 List<MyClass> result = new List<MyClass>(c);
                 for (int i = 0; i < c; i++)
                 {
                     result.Add(new MyClass(db.GetString(0, i)));
                 }

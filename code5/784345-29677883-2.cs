    public static void Insert(Class1 o)
            {
             using (var context = new NameContext())
                { //Where "o" it is an object, for example Class1 o=new Class1();
                    context.Class1s.Add(o);
                    context.SaveChanges();
                }}

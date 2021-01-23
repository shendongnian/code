    A model = context.ACollection.Where(a => a.ID == id).Select(a => 
         new A { 
             ID = a.ID, 
             b = a.b.Where(i => i.published == true).Select(i => 
                 new B{
                     published = true, 
                     c = i.c.Where(c_item => c_item.published == true),
                     d = i.d.Where(d_item => d_item.published == true)
                 })
        }).Single();

    public Noun CreateNoun(string name, string categoryName)
    {
       using (MyContext context = new MyContext())
       {
           Noun noun;
           Category category;
           lock (NounLock)
           {
              // don't create it if it already exists
              noun = context.Nouns
                        .FirstOrDefault(t => t.Name == name && t.Category.Name == categoryName);
              if (noun == null)
              {
                 // make the category if it doesn't already exist
                 lock (CategoryLock)
                 {
                   category = context.Categories.FirstOrDefault(c => c.Name == categoryName);
                   if (category == null)
                   {
                      category = new Category() { Name = categoryName };
                      context.Categories.Add(category);
                    }
                 }
                 noun = new Noun()
                 {
                   Name = name,
                   Category = category,
                 };
                 context.Nouns.Add(noun);
              }
                    
              // make sure the noun is set as active
              noun.Active = true;
              context.SaveChanges();
              return noun;
           }
       }
    }

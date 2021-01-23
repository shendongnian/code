    // these three entities are all managed separately and have already been saved elsewhere
    Technology entityFrameworkCodeFirst;
    Category objectRelationalMappers;
    Competency notThatIncompetent;
    using (DbContext context = new WhatEverYourContextIsNamed())
    {
        Resource developer = new Resource
        {
            Skills = new List<Skill> 
            {  
                new Skill
                {
                    Technology = entityFrameworkCodeFirst,
                    Category = objectRelationalMappers,
                    Competency = notThatIncompetent,
                }
            } 
        };
        context.UpdateGraph(developer, 
            map => map.OwnedCollection(r => r.Skills, 
                with => with.AssociatedEntity(skill => skill.Technology)
                            .AssociatedEntity(skill => skill.Category)
                            .AssociatedEntity(skill => skill.Competency)));
        context.SaveChanges();
    }

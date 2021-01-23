    Skill someExistingSkillThatHasAlreadyBeenSaved;
    using (DbContext context = new WhatEverYourContextIsNamed())
    {
        Resource developer = new Resource
        {
            Skills = new List<Skill> { someExistingSkillThatHasAlreadyBeenSaved } 
        };
        context.UpdateGraph(developer, map => map.AssociatedCollection(r => r.Skills));
        context.SaveChanges();
    }

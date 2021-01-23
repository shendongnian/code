            internal void Run()
        {
            //Seed();
            List<string> skills = new List<string>() { "Skill 1", "Skill 2" };
            var query = context.Freelancers
                   .Include("Skill")
                    .Where(x => x.Skill.Any(s => skills.Contains(s.Name))); 
            // query returns two freelancers, 1 and 3.
        }
        private void Seed()
        {
            Skill s1 = new Skill() { Name = "Skill 1" };
            Skill s2 = new Skill() { Name = "Skill 2" };
            Skill s3 = new Skill() { Name = "Skill 3" };
            Skill s4 = new Skill() { Name = "Skill 4" };
            Skill s5 = new Skill() { Name = "Skill 5" };
            Skill s6 = new Skill() { Name = "Skill 6" };
            Freelancer f1 = new Freelancer() { Name = "Freelancer 1" };
            f1.Skill.Add(s1);
            f1.Skill.Add(s3);
            f1.Skill.Add(s4);
            f1.Skill.Add(s6);
            Freelancer f2 = new Freelancer() { Name = "Freelancer 2" };
            f2.Skill.Add(s4);
            f2.Skill.Add(s6);
            Freelancer f3 = new Freelancer() { Name = "Freelancer 3" };
            f3.Skill.Add(s1);
            f3.Skill.Add(s6);
            Freelancer f4 = new Freelancer() { Name = "Freelancer 4" };
            f4.Skill.Add(s5);
            context.Freelancers.Add(f1);
            context.Freelancers.Add(f2);
            context.Freelancers.Add(f3);
            context.Freelancers.Add(f4);
            context.SaveChanges();
        }

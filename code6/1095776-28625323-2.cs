                      JobPost model = (JobPost)
                      (from posts in repository.JobPosts
                       orderby posts.PostDate descending
                       select new 
                       {
                           Id = posts.Id,
                           Post = posts.Post,
                           Logo = posts.Logo,
                           PostDate = posts.PostDate,
                           Employer = posts.Employer,
                           Region = posts.Region,
                           JobType = posts.JobType,
                           PostTitle = posts.PostTitle,
                           Industry = posts.Industry,
                           JobFunction = posts.JobFunction,
                           JobLevel = posts.JobLevel,
                           Salary = posts.Salary,
                           Experience = posts.Experience
                       }).Select(x => new JobPost
                       {
                           Id = x.Id,
                           Post = x.Post,
                           Logo = x.Logo,
                           PostDate = x.PostDate,
                           Employer = x.Employer,
                           Region = x.Region,
                           JobType = x.JobType,
                           PostTitle = x.PostTitle,
                           Industry = x.Industry,
                           JobFunction = x.JobFunction,
                           JobLevel = x.JobLevel,
                           Salary = x.Salary,
                           Experience = x.Experience
                       }).FirstOrDefault();
            return View(model);

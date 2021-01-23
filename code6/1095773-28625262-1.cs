    JobPost model =
                          (from posts in repository.JobPosts
                           orderby posts.PostDate descending
                           select new JobPost
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
                           }).FirstOrDefault();

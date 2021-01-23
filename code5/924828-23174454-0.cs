    public async Task<int> SaveJobSeeker(AccountInfoViewModel accountInfo, PersonalDetailViewModel personalDetail, EmploymentDetailsViewModel employmentDetails)
    {
        //create EF User object
        var user = new User {CreatedOn = DateTime.Now};
        //map data from the ViewModels into user class
        Mapper.Map(accountInfo, user);
        Mapper.Map(personalDetail, user);
        using (var db = new ITWebEntities())
        {
            //save user
            db.Users.Add(user);
            await db.SaveChangesAsync();
            //Create new EF class object and set recently saved user Id as foreign key value
            var jobSeekerEmpDetail = new JobSeekerEmploymentDetail();
            //Map other detail from the ViewModel object           
            Mapper.Map(employmentDetails, jobSeekerEmpDetail);
            jobSeekerEmpDetail.UserId = user.ID;
            //save emp details info
            db.JobSeekerEmploymentDetails.Add(jobSeekerEmpDetail);
            return await db.SaveChangesAsync();
        }
    }

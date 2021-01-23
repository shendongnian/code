    Jobseeker js = new Jobseeker();
    ....
    //assign your property to js instance
    ....
    PostJob pj = new PostJob();
    ....
    //assign your property to pj instance
    ....
    Context.PostJobs.Add(pj);
    Context.Jobseekers.Add(js);
    Context.SaveChanges();
    ApplyJob aj = new ApplyJob();
    aj.u_ID = js.Id; // after instance is saved to db EF will populate Id in instance
    aj.po_ID = pj.Id; // after instance is saved to db EF will populate Id in instance
    Context.ApplyJobs.Add(aj);
    Context.SaveChanges();

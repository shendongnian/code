    protected void Page_Load(object sender, EventArgs e)
    {
        var JobList = new List<String>() {
            "AccessibleEmployment",
            "accessIndiana",
            "AccountingNet",
            "Alldiversity.com",
            "American Chemical Society",
            "America's Job Bank",
            "Art Careers",
            "Asian MBA",
            "Back Door Jobs",
            "Career Search",
            "Careerbliss",
            "Careerbuilder",
            "CareerJet",
            "CareerMagazine",
            "CareerMosaic",
            "CareerOverview",
            "Careers 2005",
            "City of Evansville jobs",
            "College Recruiter",
            "CollegeGrad.com",
            "ComputerJobs",
            "Conservation Job Board",
            "Cuyahoga County Public Library",
            "Dentist Jobs Help",
            "EMPLOYMENTCROSSING",
            "Evansville Courier & Press Classifieds",
            "Exam2Jobs",
            "Experience.com",
            "Federal Government Jobs",
            "Flipdog",
            "FPSelectJobs",
            "hotjobs",
            "Hound",
            "Idealist",
            "Indeed",
            "Indiana Health Careers",
            "Indiana Job Central",
            "Indiana Youth Institute",
            "IndianaCAREERConnect",
            "Inside Jobs",
            "Internships",
            "Jackson County Industrial Development Corporation",
            "Jamminjobs",
            "Job Application Center",
            "Job Search USA",
            "Job Seeker's Bookmarks",
            "Job-Applications",
            "JobCo",
            "Jobs in Indianapolis Web site",
            "JobScribble",
            "Journal of Young Investors",
            "Learn More Indiana",
            "Louisville, KY jobs",
            "Mediapost",
            "NBMBAA",
            "News-Line Communications",
            "On-Line Career Center",
            "Online Recruiters Directory",
            "PeaceCorps",
            "Quintessential Careers",
            "Riley Guide",
            "RiseSmart",
            "SallieMae True Careers",
            "ScienceJobs.com",
            "Simply Hired",
            "SmartBrief",
            "Snagajob.com",
            "State government job opportunities",
            "Student Employment Opportunities",
            "Teacher Jobs Help",
            "The Ladders Career Advice",
            "U. S. Department of State",
            "USAJOBS",
            "wetfeet",
            "WomensJobSearch",
            "Work In Sports",
            "WorkplaceDiversity"
        };
        var groups = from job in JobList
                     orderby job
                     group job by job[0].ToString().ToUpper() into firstLetters
                     select firstLetters.Key;
        
        var alphabet = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z".Split(',');
        StringBuilder outputHtml = new StringBuilder();
        foreach (var letter in alphabet)
        {
            if (groups.Contains(letter))
            {
                // add html
                outputHtml.AppendFormat("<a href=\"#roulette{0}\">{1}</a> | ", letter, letter);
            }
            else
            {
                // no html
                outputHtml.Append(letter);
                outputHtml.Append(" | ");
            }
        }
        LiteralAlphaGroup.Text = outputHtml.ToString().TrimEnd(" | ".ToCharArray());
    }

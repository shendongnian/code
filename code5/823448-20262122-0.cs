    public List<int> GetRecommendedForApplication(int Application_OID)
        {
            var recommendedApplications = new List<int>();
            var context = new SomeEntities();
            int applicationId = Application_OID;
            Application application;
            do
            {
                application = (from applications in context.Applications
                               join recommendedApplication in context.Applications
                                   on applications.Application_OID equals
                                   recommendedApplication.ParentApplication_OID
                                   where recommendedApplication.ParentApplication_OID == applicationId
                               select recommendedApplication.Application_OID).FirstOrDefault();
                if (application != null)
                {
                    recommendedApplications.Add(application);
                    applicationId = application.Application_OID;
                }
            } while (application != null && application.ParentApplication_OID != null);
            return recommendedApplications;
        }

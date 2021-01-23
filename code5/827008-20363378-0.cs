      static List<SalesForceCaseComment> GetCaseCommentsFromListOfCases(List<SalesForceCase> Cases)
    {
        using (salesforce_backupsEntities le = new salesforce_backupsEntities())
        {
            List<SalesForceCaseComment> casecomments = (from c in le.CaseComments 
    join case in Cases on c.ParentId equals case.Id
    select new SalesForceCaseComment
                                                            {
                                                                CommentBody = c.CommentBody,
                                                                CreatedById = c.CreatedById,
                                                                Id = c.Id,
                                                                IsDeleted = c.IsDeleted,
                                                                IsPublished = c.IsPublished,
                                                                LastModifiedById = c.LastModifiedById,
                                                                ParentId = c.ParentId
                                                            })).ToList();
            return casecomments;              
        }
    }

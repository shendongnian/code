    public async Task<ActionResult> GetPlan(MemberViewModel request)
    {
        DocService ds = new DocService();
        List<DocType> docTypes = ds.GetDocTypesForPlan(request.PlanId);
        List<CoverageDocument> coverageDocuments = await ds.GetDocumentsForDocTypesAsync(docTypes);
        return View(coverageDocuments);
    }
    
    public async Task<List<CoverageDocument>> GetDocumentsForDocTypesAsync(List<DocType> planDocTypes)
    {
        List<CoverageDocument> planDocuments = new List<CoverageDocument>();
        DocumentUtility documentUtility = new DocumentUtility();
        int lastYear = DateTime.Now.Year - 1;
        await Task.WhenAll(planDocTypes.Select(async (docType) =>
        {
            DocumentUtility.SearchCriteria sc = new DocumentUtility.SearchCriteria();
            sc.documentType = docType;
            Dictionary<long, Tuple<string, string>> documentList = await documentUtility.FindDocuments(sc);
            documentList.ToList().ForEach((document) =>
                {
                    CoverageDocument doc = this.coverageDocumentConstructor(document);
                    planDocuments.Add(doc);
                });
        }));
        return planDocuments;
    }
    
    

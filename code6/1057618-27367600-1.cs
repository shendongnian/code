    public async Task<ActionResult> GetPlan(MemberViewModel request)
    {
        DocService ds = new DocService();
        List<DocType> docTypes = ds.GetDocTypesForPlan(request.PlanId);
        List<CoverageDocument> coverageDocuments = await ds.GetDocumentsForDocTypesAsync(docTypes);
        return View(coverageDocuments);
    }
    
    public async Task<List<CoverageDocument>> GetDocumentsForDocTypesAsync(List<DocType> planDocTypes)
    {
        DocumentUtility documentUtility = new DocumentUtility();
        int lastYear = DateTime.Now.Year - 1;
        var planDocuments = await Task.WhenAll(planDocTypes.Select(async (docType) =>
        {
            DocumentUtility.SearchCriteria sc = new DocumentUtility.SearchCriteria();
            sc.documentType = docType;
            
            return await documentUtility.FindDocuments(sc).Select((document) => this.coverageDocumentConstructor(document))
        }));
        return planDocuments.SelectMany(doc => doc);;
    }
    
    

    [HttpPost]
    public ActionResult PacSearch(string pacupc)
    {
        if (pacupc != null)
        {
            try
            {
                PriceAssociationLookup pacRep = new PriceAssociationLookup();
                //List<PriceAssociationLookup> matchingPacs = pacRep.GetPacs(pacupc);
                return PartialView("_PacSearchResultsPartial", pacRep.GetPacs(pacupc));
            }
            catch (Exception e)
            {
                Alert.SetAlert(this.HttpContext, String.Format("There was an error in the Price Association Code lookup for UPC {0}.  Error: {1}", pacupc, e), "alert-warning");
            }
        }
        return PartialView("_PacSearchResultsPartial","UPC not found");
    }

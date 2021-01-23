    public ActionResult GetXML(long productionOrderId) //Changed Return Type
    {
        ProductionOrderReport poReport = null;
    
        poReport = new ProductionOrderReport(m_Repository, m_AggRepo, m_AggChildsRepo);
    
        // Get the XML document for this Production Order.
        XDocument doc = poReport.GenerateXMLReport(productionOrderId);
    
        if (doc != null)
        {
            // Convert it to string.
            StringWriter writer = new Utf8StringWriter();
            doc.Save(writer, SaveOptions.None);
    
            // Convert the string to bytes.
            byte[] bytes = Encoding.UTF8.GetBytes(writer.ToString());
    
            return File(bytes, "application/xml", "report.xml");
        }
        else
            return RedirectToAction("ViewName","ControllerName"); //Instead of returning null, you can redirect back to the GET action of the original view.
    }

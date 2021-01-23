    using (var db = new VetexV2.pesqlshareEntities1())
    {
        // query code as above
        // other possible code...
      
        foreach (var item in query)
        {
            pat.PostalCode = item.JobZip;
            pat.MainDivision = item.StateCode;
            pat.Country = item.Country;
            pat.City = item.JobCity;
            pat.StreetAddress1 = item.Address1;
            pat.StreetAddress2 = item.Address2;
                  
            //... other code omitted for brevity
                  
            soap.LookupTaxAreas60(ref LTAR.VertexEnvelope);
            var reslt = ((VertexWebService.TaxAreaResponseType)(LTAR.VertexEnvelope.Item))
                       .TaxAreaResult[0].taxAreaId.ToString();
    
            item.VertexGeoCode = reslt;
            // other code...        
        }
        db.SaveChanges();
    }

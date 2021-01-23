    private static void FixPowerpoint(string fileName)
    {
      //Opening the package associated with file
      using (Package wdPackage = Package.Open(fileName, FileMode.Open, FileAccess.ReadWrite))
      {
        //Uri of the printer settings part
        var binPartUri = new Uri("/ppt/printerSettings/printerSettings1.bin", UriKind.Relative);
        if (wdPackage.PartExists(binPartUri))
        {
          //Uri of the presentation part which contains the relationship
          var presPartUri = new Uri("/ppt/presentation.xml", UriKind.RelativeOrAbsolute);
          var presPart = wdPackage.GetPart(presPartUri);
          //Getting the relationship from the URI
          var presentationPartRels =
              presPart.GetRelationships().Where(a => a.RelationshipType.Equals("http://schemas.openxmlformats.org/officeDocument/2006/relationships/printerSettings",
                  StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
          if (presentationPartRels != null)
          {
            //Delete the relationship
            presPart.DeleteRelationship(presentationPartRels.Id);
          }
    
          //Delete the part
          wdPackage.DeletePart(binPartUri);
        }
        wdPackage.Close();
      }
    }

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Packaging;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml;
    
    namespace OpenXmlDemo
    {
        class PptOpenXmlDemo
        {
            public int PptGetSlideCount(string fileName)
            {
                //  Return the number of slides in a PowerPoint document.
                const string documentRelationshipType = "http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument";
                const string presentationmlNamespace = "http://schemas.openxmlformats.org/presentationml/2006/main";
    
                int returnValue = 0;
    
                using (Package pptPackage = Package.Open(fileName, FileMode.Open, FileAccess.Read))
                {
                    //  Get the main document part (presentation.xml).
                    foreach (System.IO.Packaging.PackageRelationship relationship in pptPackage.GetRelationshipsByType(documentRelationshipType))
                    {
                        //  There should be only a single relationship that refers to the document.
                        Uri documentUri = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), relationship.TargetUri);
                        PackagePart documentPart = pptPackage.GetPart(documentUri);
    
                        //  Get the slide part from the package.
                        if (documentPart != null)
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(documentPart.GetStream());
    
                            //  Manage namespaces to perform XPath queries.
                            XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                            nsManager.AddNamespace("p", presentationmlNamespace);
    
                            //  Retrieve the list of slide references from the document.
                            XmlNodeList nodes = doc.SelectNodes("//p:sldId", nsManager);
                            if (nodes != null)
                            {
                                returnValue = nodes.Count;
                            }
                        }
                        //  There is only one officeDocument part. Get out of the loop now.
                        break;
                    }
                }
                return returnValue;
            }
        }
    }

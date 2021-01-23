    public class XpsFile
    {
        /// <summary>
        /// Regex to validate XPS "indices" property (gotten from ABCPDF)
        /// </summary>
        private static readonly string IndicesRegex = @"(((\(([1-9][0-9]*)(:([1-9][0-9]*))?\))?([0-9]+))?(,(\+?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?)?(,((\-|\+)?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?)?(,((\-|\+)?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?))?)?)?)(;((\(([1-9][0-9]*)(:([1-9][0-9]*))?\))?([0-9]+))?(,(\+?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?)?(,((\-|\+)?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?)?(,((\-|\+)?(([0-9]+(\.[0-9]+)?)|(\.[0-9]+))((e|E)(\-|\+)?[0-9]+)?))?)?)?)*";
 
        /// <summary>
        /// Fixes the XPS problems it encounters and knows about
        /// </summary>
        public static void FixXps(string filePath)
        {
            // first we'll load the XPS file
            using (var currentPackage = Package.Open(filePath, FileMode.Open))
            {
                var pageUri = new Uri("/Documents/1/Pages/1.fpage", UriKind.Relative);
 
                // check that the file we'll modify exists
                if (!currentPackage.PartExists(pageUri))
                {
                    throw new Exception(string.Format("Unable to find first page in XPS {0} - unable to fix this XPS !", filePath));
                }
 
                // assume the broken part is in the first page
                var firstPage = currentPackage.GetPart(pageUri);
                var relationships = firstPage.GetRelationships();
                var pageContent = XDocument.Load(firstPage.GetStream());
 
                // then we'll look up each glyph and check if their "Indices" property is valid
                XNamespace ns = pageContent.Root.GetDefaultNamespace();
                var glyphs = (from g in pageContent.Descendants(ns + "Glyphs")
                              where g.Attribute("Indices") != null
                              select g).ToList();
                for (var i = 0; i < glyphs.Count(); i ++)
                {
                    glyphs[i] = FixGlyph(glyphs[i]);
                }
 
                // remove the current (corrupted) file from the package
                currentPackage.DeletePart(pageUri);
 
                // add the new (shiny) file to the package
                var newPage = currentPackage.CreatePart(pageUri, "application/vnd.ms-package.xps-fixedpage+xml", CompressionOption.NotCompressed);
                using (var ms = new MemoryStream())
                {
                    // we need to remove XML declaration, so we need to use the XmlWriter
                    var settings = new XmlWriterSettings();
                    settings.Indent = false;
                    settings.NewLineChars = string.Empty;
                    settings.NewLineHandling = NewLineHandling.Replace;
                    settings.OmitXmlDeclaration = true;
                    using (var xw = XmlWriter.Create(ms, settings))
                    {
                        pageContent.WriteTo(xw);
                    }
 
                    ms.Seek(0, SeekOrigin.Begin);
                    CopyStream(newPage.GetStream(), ms);
                }
 
                // now we need to re-create the relationships between the Page file and the fonts
                foreach (var relation in relationships)
                {
                    newPage.CreateRelationship(relation.TargetUri, relation.TargetMode, relation.RelationshipType, relation.Id);
                }
            }
        }
 
        /// <summary>
        /// Tries to load the XPS, and returns false if it fails
        /// </summary>
        public static bool IsValidXps(string filePath)
        {
            try
            {
                using (var xpsOld = new XpsDocument(filePath, FileAccess.Read))
                {
                    var unused = xpsOld.GetFixedDocumentSequence();
                }
 
                return true;
            }
            catch (System.Windows.Markup.XamlParseException)
            {
                return false;
            }
        }
 
        /// <summary>
        /// Writes the whole content of a stream into another
        /// </summary>
        /// <remarks>
        /// http://stackoverflow.com/a/18885954/2354542
        /// </remarks>
        private static void CopyStream(Stream target, Stream source)
        {
            const int bufSize = 0x1000;
            byte[] buf = new byte[bufSize];
            int bytesRead = 0;
            while ((bytesRead = source.Read(buf, 0, bufSize)) > 0)
            {
                target.Write(buf, 0, bytesRead);
            }
        }
 
        /// <summary>
        /// Fixes the glyph, if necessary
        /// </summary>
        private static XElement FixGlyph(XElement g)
        {
            var matchAttribute = Regex.Match(g.Attribute("Indices").Value, IndicesRegex);
            if (!matchAttribute.Success)
            {
                return g;
            }
 
            var hasProblem = false;
            foreach (var token in matchAttribute.Value.Split(";".ToCharArray()))
            {
                if (token == ",")
                {
                    hasProblem = true;
                    break;
                }
            }
 
            if (hasProblem)
            {
                // the Indices attribute is not well-formed: let's try to fix the one(s) that are wrong
                var fixedTokens = new List<string>();
                foreach (var token in g.Attribute("Indices").Value.Split(";".ToCharArray()))
                {
                    var newToken = token;
                    var matchToken = Regex.Match(token, @",(-\d+)");
                    if (matchToken.Success) // negative number, yay ! it's not allowed :-(
                    {
                        newToken = ",0"; // it should be zero, I believe
                    }
 
                    fixedTokens.Add(newToken);
                }
 
                g.Attribute("Indices").Value = string.Join(";", fixedTokens);
            }
 
            return g;
        }
    }

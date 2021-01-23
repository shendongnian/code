        static void CopyLayout(string srcFile, string destFile)
        {
            var oldModel = XDocument.Load(srcFile);
            var newModel = XDocument.Load(destFile);
            XNamespace edmxNs = "http://schemas.microsoft.com/ado/2009/11/edmx";
            // find all entity shapes
            var oldEts = oldModel.Root.Descendants(edmxNs + "EntityTypeShape").Select(ets => ets).ToList();
            var newEts = newModel.Root.Descendants(edmxNs + "EntityTypeShape").Select(ets => ets).ToList();
            // replace any matching new with old
            foreach (var newEt in newEts)
            {
                var match = oldEts.SingleOrDefault(ot => ot.Attribute(@"EntityType").Value ==
                                                         newEt.Attribute(@"EntityType").Value);
                if (match != null)
                    newEt.ReplaceAttributes(match.Attributes());
            }
            newModel.Save(destFile);
        }

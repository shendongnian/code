        XmlDocument MergeDocs(string SourceA, string SourceB)
        {
            XmlDocument docA = new XmlDocument();
            XmlDocument docB = new XmlDocument();
            XmlDocument merged = new XmlDocument();
            docA.LoadXml(SourceA);
            docB.LoadXml(SourceB);
            var childsFromA = docA.ChildNodes.Cast<XmlNode>();
            var childsFromB = docB.ChildNodes.Cast<XmlNode>();
            var uniquesFromA = childsFromA.Where(ch => childsFromB.Where(chb => chb.Name == ch.Name).Count() == 0);
            var uniquesFromB = childsFromB.Where(ch => childsFromA.Where(chb => chb.Name == ch.Name).Count() == 0);
            foreach (var unique in uniquesFromA)
                merged.AppendChild(DeepCloneToDoc(unique, merged));
            foreach (var unique in uniquesFromA)
                merged.AppendChild(DeepCloneToDoc(unique, merged));
            var Duplicates = from chA in childsFromA
                             from chB in childsFromB
                             where chA.Name == chB.Name
                             select new { A = chA, B = chB };
            foreach (var grp in Duplicates)
                merged.AppendChild(MergeNodes(grp.A, grp.B, merged));
            return merged;
        
        }
        XmlNode MergeNodes(XmlNode A, XmlNode B, XmlDocument TargetDoc)
        {
            var merged = TargetDoc.CreateNode(A.NodeType, A.Name, A.NamespaceURI);
            foreach (XmlAttribute attrib in A.Attributes)
                merged.Attributes.Append(TargetDoc.CreateAttribute(attrib.Prefix, attrib.LocalName, attrib.NamespaceURI));
            var fromA = A.Attributes.Cast<XmlAttribute>();
            var fromB = B.Attributes.Cast<XmlAttribute>();
            
            var toAdd = fromB.Where(attr => fromA.Where(ata => ata.Name == attr.Name).Count() == 0);
            foreach (var attrib in toAdd)
                merged.Attributes.Append(TargetDoc.CreateAttribute(attrib.Prefix, attrib.LocalName, attrib.NamespaceURI));
            var childsFromA = A.ChildNodes.Cast<XmlNode>();
            var childsFromB = B.ChildNodes.Cast<XmlNode>();
            var uniquesFromA = childsFromA.Where(ch => childsFromB.Where(chb => chb.Name == ch.Name).Count() == 0);
            var uniquesFromB = childsFromB.Where(ch => childsFromA.Where(chb => chb.Name == ch.Name).Count() == 0);
            foreach (var unique in uniquesFromA)
                merged.AppendChild(DeepCloneToDoc(unique, TargetDoc));
            foreach (var unique in uniquesFromA)
                merged.AppendChild(DeepCloneToDoc(unique, TargetDoc));
            var Duplicates = from chA in childsFromA
                             from chB in childsFromB
                             where chA.Name == chB.Name
                             select new { A = chA, B = chB };
            foreach(var grp in Duplicates)
                merged.AppendChild(MergeNodes(grp.A, grp.B, TargetDoc));
            return merged;
        }
        XmlNode DeepCloneToDoc(XmlNode NodeToClone, XmlDocument TargetDoc)
        {
            var newNode = TargetDoc.CreateNode(NodeToClone.NodeType, NodeToClone.Name, NodeToClone.NamespaceURI);
            foreach (XmlAttribute attrib in NodeToClone.Attributes)
                newNode.Attributes.Append(TargetDoc.CreateAttribute(attrib.Prefix, attrib.LocalName, attrib.NamespaceURI));
            foreach (XmlNode child in NodeToClone.ChildNodes)
                newNode.AppendChild(DeepCloneToDoc(NodeToClone, TargetDoc));
            return newNode;
        
        }

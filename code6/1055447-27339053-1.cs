        static Application onenoteApp = new Application();
        static XNamespace ns = null;
        static void Main(string[] args)
        {
            GetNamespace();
            string notebookId = GetObjectId(null, OneNote.HierarchyScope.hsNotebooks, "MyNotebook");
            string sectionId = GetObjectId(notebookId, OneNote.HierarchyScope.hsSections, "Sample_Section");
            string firstPageId = GetObjectId(sectionId, OneNote.HierarchyScope.hsPages, "MyPage");
            GetPageContent(firstPageId);
            Console.Read();
        }
        static void GetNamespace()
        {
            string xml;
            onenoteApp.GetHierarchy(null, OneNote.HierarchyScope.hsNotebooks, out xml);
            var doc = XDocument.Parse(xml);
            ns = doc.Root.Name.Namespace;
        }
        static string GetObjectId(string parentId, OneNote.HierarchyScope scope, string objectName)
        {
            string xml;
            onenoteApp.GetHierarchy(parentId, scope, out xml);
            var doc = XDocument.Parse(xml);
            var nodeName = "";
            switch (scope)
            {
                case (OneNote.HierarchyScope.hsNotebooks): nodeName = "Notebook"; break;
                case (OneNote.HierarchyScope.hsPages): nodeName = "Page"; break;
                case (OneNote.HierarchyScope.hsSections): nodeName = "Section"; break;
                default:
                    return null;
            }
            var node = doc.Descendants(ns + nodeName).Where(n => n.Attribute("name").Value == objectName).FirstOrDefault();
            return node.Attribute("ID").Value;
        }
        static string GetPageContent(string pageId)
        {
            string xml;
            onenoteApp.GetPageContent(pageId, out xml, OneNote.PageInfo.piAll);
            var doc = XDocument.Parse(xml);
            var outLine = doc.Descendants(ns + "Outline").First();
            var content = outLine.Descendants(ns + "T").First();
            string contentVal = content.Value;
            content.Value = "modified";
            onenoteApp.UpdatePageContent(doc.ToString());
            return null;
        }

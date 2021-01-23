    void ThisApplication_MailMergeAfterMerge(Word.Document Doc, Word.Document DocResult)
        {
            DocResult.Fields.Update();
            // remove customization
            Office.DocumentProperties properties = (Office.DocumentProperties) DocResult.CustomDocumentProperties;
            properties["_AssemblyName"].Delete();
            properties["_AssemblyLocation"].Delete();
            DocResult.RemoveDocumentInformation(Word.WdRemoveDocInfoType.wdRDIDocumentProperties);
            foreach (XMLSchemaReference reference in DocResult.XMLSchemaReferences)
            {
                if (reference.NamespaceURI.Contains("ActionsPane"))
                {
                    reference.Delete();
                }
            }
            ThisApplication.Visible = true;
            ThisApplication.NormalTemplate.Saved = true;
            Doc.MailMerge.DataSource.Close();
        }

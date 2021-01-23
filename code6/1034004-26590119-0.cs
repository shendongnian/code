    public static XElement Translate(string xamlFile)
        {
            string translatedWorkflowString = null;
            using (XamlReader xamlReader = new XamlXmlReader(xamlFile))
            {
                TranslationResults result = ExpressionTranslator.Translate(xamlReader);
                if (result.Errors.Count == 0)
                {
                    StringBuilder sb = new StringBuilder();
                    using (XmlWriter xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true }))
                    {
                        using (XamlXmlWriter writer = new XamlXmlWriter(xmlWriter, result.Output.SchemaContext))
                        {
                            XamlServices.Transform(result.Output, writer);
                        }
                    }
                    translatedWorkflowString = sb.ToString();
                }
                else
                {
                    throw new InvalidOperationException("Translation errors");
                }
            }
            return XElement.Parse(translatedWorkflowString);
        }

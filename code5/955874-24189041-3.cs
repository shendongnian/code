                    XmlNamespaceManager nsmgr = new XmlNamespaceManager(trxFile.NameTable);
                    nsmgr.AddNamespace("vstt", "http://microsoft.com/schemas/VisualStudio/TeamTest/2010");
                    // get result node for this testcase from trx file
                    XmlNode node =
                        trxFile.SelectSingleNode(
                            "//vstt:UnitTestResult[@testName=\"SourceWorkflowAsSvcWhenErrorConvertingFile\"]/vstt:Output/vstt:ErrorInfo",
                            nsmgr);
                    if (node != null)
                    {
                        Console.WriteLine("Stack Trace: " + node.InnerText);
                    }

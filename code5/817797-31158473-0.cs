    var webClient = new System.Net.WebClient();
    var data = webClient.DownloadData(myPath);
    var package = System.IO.Packaging.Package.Open(new System.IO.MemoryStream(data));
    var xpsDocument = new System.Windows.Xps.Packaging.XpsDocument(package,
                                                              System.IO.Packaging.CompressionOption.SuperFast,
                                                              myPath);
    var sequence = xpsDocument.GetFixedDocumentSequence();

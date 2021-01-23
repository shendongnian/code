    public async Task<ActionResult> CreateExcelFile()
            {
                LiveLoginResult loginStatus = await authClient.InitializeWebSessionAsync(HttpContext);
                if (loginStatus.Status == LiveConnectSessionStatus.Connected)
                {
                    connectedClient = new LiveConnectClient(this.authClient.Session);
                    string url = "https://apis.live.net/v5.0/me/skydrive/files?access_token=" + this.authClient.Session.AccessToken;
    
                    XSSFWorkbook wb = new XSSFWorkbook();
    
                    // create sheet
                    XSSFSheet sh = (XSSFSheet)wb.CreateSheet("Sheet1");
                    // 10 rows, 10 columns
                    for (int i = 0; i < 100; i++)
                    {
                        var r = sh.CreateRow(i);
                        for (int j = 0; j < 100; j++)
                        {
                            r.CreateCell(j);
                        }
                    }
    
                    MemoryStream stream = new MemoryStream();
                    wb.Write(stream);
                    stream.Dispose();
    
                    var arrBites = stream.ToArray();
    
                    MemoryStream newStream = new MemoryStream(arrBites);
    
                    var docFile = File(newStream, "application/octet-stream", "Excel.xlsx");
                    MemoryStream streamFile = new MemoryStream();
                    docFile.FileStream.Position = 0;
                    docFile.FileStream.CopyTo(streamFile);
    
                    var bites = streamFile.ToArray();
                    Stream stream2 = new MemoryStream(bites);
    
                    try
                    {
                        LiveOperationResult getResult = await connectedClient.UploadAsync("me/skydrive", docFile.FileDownloadName, stream2, OverwriteOption.Overwrite);
                    }
                    catch (WebException ex)
                    {
    
                    }
                }
                return View();
            }

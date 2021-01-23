    using (WebClient webClient = new WebClient())
                    {
                        // nastaveni ze webClient ma pouzit Windows Authentication
                        webClient.UseDefaultCredentials = true;    
                        // spusteni stahovani
                        webClient.DownloadFile(new Uri("http://czprga2001/Logio_ZelenyKyblik/Export.ashx"), Path.Combine(TempDirectory, PSFileName));
                    }
    ExcelToCsv(Path.Combine(TempDirectory, PSFileName));  //No need to create the event handler if it is not async

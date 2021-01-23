     const string serviceAccountEmail = "716698526626-6s61a3tbe1m5mofo9@developer.gserviceaccount.com";
        const string serviceAccountPKCSP12FilePath = @"C:\SVN\GAPforInboundandWeb-1f6bfb.p12";
        X509Certificate2 certificate = new X509Certificate2(serviceAccountPKCSP12FilePath, "notasecret", X509KeyStorageFlags.Exportable);
        ServiceAccountCredential credential = new ServiceAccountCredential(
            new ServiceAccountCredential.Initializer(serviceAccountEmail)
            {
                Scopes = new[] { AnalyticsService.Scope.Analytics }
            }.FromCertificate(certificate));
        var service = new AnalyticsService(new BaseClientService.Initializer
        {
            HttpClientInitializer = credential,
            ApplicationName = "GAPforInboundandWeb"
        });
        FileStream realCsv = new FileStream("c:\\real.csv", FileMode.Open);
        // Create the service.
        try
        {
            var dataSource = srv.Management.CustomDataSources.List(AccountId, WebId).Execute();
            var strDataSourceId = "Oy_0JTPvRGCB3Vg5OKVIMQ";
            if(dataSource!=null && dataSource.Items.Length>0)
              strDataSourceId =dataSource.Items[0].Id;
            var upload = service.Management.DailyUploads.Upload("50288725", "UA-50288725-1", strDataSourceId,
                "2014-09-22", 1, ManagementResource.DailyUploadsResource.UploadMediaUpload.TypeEnum.Cost, realCsv,
                "application/octet-stream");
            upload.Reset = true;
            var res = upload.Upload();
            res.BytesSent.ToString();
            res.Status.ToString();
        }

    private class cfileRecs
            {
    
                public int Year { get; set; }
                public string session { get; set; }
                public string center { get; set; }
                public string fileNameRaw { get; set; }
    
            }
    
            private class cfiles
            {
                public string FileName { get; set; }
            }
    
    List<cfileRecs> dbScanRecords = new List<cfileRecs>() { 
                    new cfileRecs(){ center = "a", fileNameRaw ="abc.pdf", 
                    session="aaa", Year=1999}};    
    
    List<cfiles> awsScanObjects = new List<cfiles>() { 
                    new cfiles(){ FileName = "abc.pdf"},
                    new cfiles(){ FileName = "bbb"}
                };
    
    var filesNotFound = (from files in awsScanObjects
                      join recs in dbScanRecords 
                      on files.FileName equals recs.fileNameRaw into grp
                      from g in grp.DefaultIfEmpty()
                      select new { dbfile = g == null ? null : g.fileNameRaw,
                      awsfile = files.FileName })
                       .Where(x => x.dbfile == null).ToList();

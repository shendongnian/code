    WebClient webClient = new WebClient();
    TextReader textReader = new StreamReader(new MemoryStream(
                    webClient.DownloadData("http://selfservice.diges.dk:9080/selfservice/download/prisbog/VARPOST.CSV")));
     var csvReader = new CsvParser(textReader);
     List<Record> records = new List<Record>();
     while (true)
     {
         var row = csvReader.Read();
         if (row == null)
         {
             break;
         }
         records.Add(new Record()
         {
             Column1 = row[0],
             Column2 = row[1],
             Column3 = row[2],
             Column4 = row[3],
             Column5 = row[4],
             Column6 = row[5],
             Column7 = row[6]
         });
     }
    public class Record
    {
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public string Column4 { get; set; }
        public string Column5 { get; set; }
        public string Column6 { get; set; }
        public string Column7 { get; set; }
    }

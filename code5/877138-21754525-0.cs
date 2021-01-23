    public static string GetSha1Sum()
    {
         double sum =0;
         using (CSVReader cr = new CSVReader(myfilename)) {
             foreach (string[] line in cr) {
                  //assuming your field is the first : 
                 sum += Convert.ToDouble(line[0]);
             }
         }
         SHA1 sha1Hash= SHA1.Create();
         byte[] data = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(sum.ToString()));
         string digest = HexDigest(data);
     }

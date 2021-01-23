    static void Main(string[] args)
    {
         using (var site = new SPSite("http://intranet.contooso.com"))
         {
              using (var web = site.OpenWeb())
              {
                        Console.WriteLine(web.Name);
              }
         }
    }

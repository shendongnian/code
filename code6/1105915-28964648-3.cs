    public int Start()
    {
        var rxDelim = new Regex(@"(?(:):\s*|\s{3,})\s*");
        var inputStr = @"// This is a comment
                     // NotUsed : 123654
    
    ****************************************
    *          DESCRIPTION
    ***************************************
    Header:         xxx
    Date:           20010101    
    ReqDate:20150402
    P.O.            123456
    Qty         10000
    Part Number:     xx-yy-456
    Type:           J
    Product:            xxyy123456V0.01 (bulk) 
    Cust ID:    51
    Model:          
    Location:       60
    UPC:            123456
    *
    cust_ref:       Hello Worlkd
    *
    ***************************************
    *          Data
    ***************************************";
    
    var stream = new MemoryStream(Encoding.UTF8.GetBytes(inputStr));
    var line = string.Empty;
    using (var r = new StreamReader(stream))
    {
        var data = new Data();
        var s = string.Empty;
        while ((s = r.ReadLine()) != null)
        {
            if (Regex.IsMatch(s, @"(?i)^\*[^\r\n]*Description"))
            {
               s = r.ReadLine() + "\r\n";
               line += s;
               var add = r.ReadLine() + "\r\n";
               while (add != null && !Regex.IsMatch(add, @"(?i)^\*[^\r\n]*Description"))
               {
                   line += add + "\r\n";
                   add = r.ReadLine();
               }
               var matches = line.Split(new[] { "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries).Select(p => rxDelim.Split(p).GetLength(0) > 1 && rxDelim.Split(p)[0] != "*" && !rxDelim.Split(p)[0].TrimStart(new[] { ' ' }).StartsWith("//") ?
                       new { Key = rxDelim.Split(p)[0], Value = rxDelim.Split(p)[1] } :
                       new { Key = string.Empty, Value = string.Empty });
               foreach (var v in matches)
               {
                   if (!String.IsNullOrWhiteSpace(v.Key) && !String.IsNullOrWhiteSpace(v.Value))
                   {
                       switch (v.Key)
                       {
                          case "Header":
                               data.Header = v.Value;
                               break;
                          case "ReqDate":
                               data.RequestedDeliveryDate = v.Value;
                               break;
                          case "Qty":
                               data.Qty = Convert.ToInt32(v.Value);
                               break;
                          case "Type":
                               data.Type = v.Value;
                               break;
                       }
                   }
               }
            }
        }
    }
    return 0;
    }

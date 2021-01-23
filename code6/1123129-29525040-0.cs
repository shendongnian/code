    List<StatusPedido> ListaItems;
    
            Console.WriteLine("Getting articles from excel file");
            var excel = new ExcelQueryFactory(ExcelFileURI);
            excel.DatabaseEngine = DatabaseEngine.Ace;
    
            //var Items = from c in excel.Worksheet<StatusPedido>(sheetName)
            var Items = from c in excel.Worksheet<StatusPedido>(sheetName)
                        select c;
    foreach(var x in items)
    {
    StatusPedido objData=new StatusPedido();
    objData.val1=x.val1;
    .
    .
    .
    ListaItems.Add(objData);
    
    }
    return ListaItems;

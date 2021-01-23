    public void MainMethod()
    {
       var productlist=GetProducts();  
       string excelfile=GetExcelFile(productlist);
    
       // do something in the excel file
    }
    
    public List<product> GetProducts()
    {
       var _products = new Products();
       return _products.GetProductList;
    }
    
    public string GetExcelFile(List<product> productlist)
    {
       var _getExcelFile = new GetExcelFile();
       var excelfile = _getExcelFile.GetExcelFileFromProductList(productlist);
    
       return excelfile; 
    }

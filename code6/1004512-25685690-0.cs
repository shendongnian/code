     string []Stocks={"1,2,3","2,4,5","3","4"};
            string temp_stocks = string.Join(",", Stocks);
    
            string[] splited_temp_stocks;
         
            splited_temp_stocks = temp_stocks.Split(',');
         
            var series = new Collection<Serie>();
            series.Add(new Serie { name = "Current Stock", data = splited_temp_stocks }); 

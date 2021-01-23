    public  dynamic  CalculateAndSaveToDB(BMICalculation CalculateModel)
    {
       ...
       return  CalculateAndSaveToDB(CalculateModel.BMICalc.ToString(), CalculateModel.BMIMeaning.ToString());
    }  
    public dynamic CalculateAndSaveToDB(string o, string t)
    {
        dynamic data = new new ExpandoObject();
         
        data.CalculatedBMI = o;
        data.CalculatedBMIMeaning = t;
        
        return  data ;
    }

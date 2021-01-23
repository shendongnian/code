    public static Dictionary<string,string> GetValues(string command)
    {
       Dictionary<string,string> output = new    Dictionary<string,string>();
       string[] splitCommand =  command.Split(" ");
       
       foreach(var item in splitCommand)
       {
          output.Add(item.Split("=")[0] , item.Split("=")[1]);
       }
    
      return output;
    }

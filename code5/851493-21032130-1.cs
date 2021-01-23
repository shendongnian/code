    static void Main(string[] args)
    {
        try
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.MissingMemberHandling = MissingMemberHandling.Error;
            var goodObj = JsonConvert.DeserializeObject<MyJsonObjView>(correctData, settings);
            System.Console.Out.WriteLine(goodObj.MyJsonInt.ToString());
            var badObj = JsonConvert.DeserializeObject<MyJsonObjView>(wrongData, settings);
            System.Console.Out.WriteLine(badObj.MyJsonInt.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
        }
    }

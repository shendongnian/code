    public class ServerFunctions
    {
        public static async Task<List<BdeskDocLib>> GetDocLibs(bool onlyDocLibPerso)
        {
            string xmlContent = await GetXml();
            List<BdeskDocLib> result = BdeskDocLib.GetListFromXml(xmlContent,  onlyDocLibPerso);
            return result;
        }
    
       private async static Task<String> GetXml()
        {  
            Task<String>task=requesteur.Query(dataRequestParam);
            task.Wait();
            xmlResult = task.Result;
            return xmlResult;
        }
    }

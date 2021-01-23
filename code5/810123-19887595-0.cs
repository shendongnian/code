    namespace ServerProj
    {
        using System.ServiceModel;
        using Common;
    
        [ServiceContract]
        public interface IRCommService
        {
            [OperationContract]
            Result SendMessage(string command, CustomRequest data);
        }
    }
    namespace ServerProj
    {
        using System.Collections.Generic;
        using Common;
        public class RCommService : IRCommService
        {
            public Result SendMessage(string command, CustomRequest data)
            {   // You can get the value from here
                int value = data.MyValue;
    
                Result result = new Result();
                List<string> list = new List<string>();
                list.Add("Sample");
                result.Rsults = list;
    
                return result;
            }
        }
    }

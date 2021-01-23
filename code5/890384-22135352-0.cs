    namespace MyDLL
    {
        public class clsDLL
        {
            ThirdPartyAPI _api = new ThirdPartyAPI();
            double _X = 0;
    
            public double X {return _X; }
    
            public int open(string uKey)
            {
                int iRet = _api.Open(uKey);
                return iRet;
            }
    
            //This is a callback that will be called by "_api"
            private static void CallBack_MoveDetected(ref MoveData data, 
                                IntPtr userData, clsDLL instance)
            {
                instance.X=data.positionX; 
            }
        }
    }

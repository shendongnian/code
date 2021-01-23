    namespace MyDLL
    {
        public class clsDLL
        {
            ThirdPartyAPI _api = new ThirdPartyAPI();
            double _X = 0;
    
            public double X 
            { 
               get{ return _X;} 
               set{ _X = value;}
            }
    
            public int open(string uKey)
            {
                int iRet = _api.Open(uKey);
                return iRet;
            }
    
            private static void CallBack_MoveDetected(ref MoveData data, 
                                IntPtr userData, clsDLL instance)
            {
                instance.X=data.positionX; 
            }
        }
    }

    config.Services.Replace(typeof(IHostBufferPolicySelector), new CustomBufferPolicySelector());  
    
    //---------------  
    
    public class CustomBufferPolicySelector : WebHostBufferPolicySelector
    {
        public override bool UseBufferedInputStream(object hostContext)
        {
            return false;
        }
    }
 

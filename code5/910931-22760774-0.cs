    [ContractClass(typeof(IRequestContract))]
    public interface IRequest
    {
        [DataMember(IsRequired = true)]
        string EndUserIp { get; set; }
    
        [DataMember(IsRequired = true)]
        string TokenId { get; set; }
    
        [DataMember(IsRequired = true)]
        string ClientId { get; set; }
    
        [DataMember(IsRequired = true)]
        int TokenAgencyId { get; set; }
    
        [DataMember(IsRequired = true)]
        int TokenMemberId { get; set; }
    }
    
    
    [ContractClassFor(typeof(IRequest))]
    internal abstract class IRequestContract : IRequest
    {
        string EndUserIp
    	{ 
    		get
    		{
    			return null;
    		}
    		set
    		{
    			Contract.Requires<BusinessServiceException>(!string.IsNullOrWhiteSpace(value), "IP Address should not be Null or Empty");
    			Contract.Requires<BusinessServiceException>(!IsValidIp(request.EndUserIp, "IP Address is not in correct Format");
    		}
    	}
    
        string TokenId 
    	{ 
    		get
    		{
    			return null;
    		}
    		set
    		{
    			Contract.Requires<BusinessServiceException>(!string.IsNullOrWhiteSpace(value), "TokenID should not be Null or Empty");
    			Contract.Requires<BusinessServiceException>(!IsValidTokenId(request.TokenId), "TokenID is not in correct Format");
    		}
    	}
    		
    	string ClientId 
    	{ 
    		get
    		{
    			return null;
    		}
    		
    		set
    		{
    			Contract.Requires<BusinessServiceException>(!string.IsNullOrWhiteSpace(value), "ClientId can not be null or Empty");
    		}
    	}
    	
        int TokenAgencyId 
    	{ 
    		get
    		{
    			return default(int);
    		}
    		set
    		{
    		    Contract.Requires<BusinessServiceException>(value < 0, "TokenAgencyId should be positive Integer");
    		}
    	}
    
        int TokenMemberId 
    	{ 
    		get
    		{
    			return null;
    		}
    		set
    		{
    		     Contract.Requires<BusinessServiceException>(value < 0, "TokenMemberId should be positive Integer");
    		}
    	}
    }

    public interface IRequest {
      String TokenId {get;}
      String IpAddress {get;}
      ... 
    } 
    
    public interface IResponse {
      ...
    } 
    
    public class LoadSupplierResponse: IResponse {...}
    
    public class ChangePasswordResponse: IResponse {...}
    
    public class LoadSupplierRequest: IRequest {...}
    
    public class ChangePasswordRequest: IRequest {...}
    
    public static class Util {
      ...
      public static String Serialize(IRequest value) {...} 
      public static String Serialize(IResponse value) {...} 
    } 
    
    public class UserProfile : IUserProfile {
      private static void GetAudit(IRequest request, 
                                   IResponse response,
                                   int memberID,
                                   RemoteEndpointMessageProperty endpointProperty) {
        string auditText = "LoadSupplier Req:";
        auditText += Util.Serialize(request).ToString(CultureInfo.InvariantCulture);
        auditText += "Res:";
        auditText += Util.Serialize(response).ToString(CultureInfo.InvariantCulture);
        Audit.Add(AuditEventType.LoadSupplier, 
                  Severity.Normal, 
                  memberID, 
                  request.TokenId,
                  auditText,
                  endpointProperty.Address, 
                  request.IpAddress);
      }
      ...
    }

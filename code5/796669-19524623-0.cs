    public class Param //at server side
    {
       public int recordId { get; set; }
       public int transToPropId { get; set; }
       public int receivedViaTypeId { get; set; }
       public string recordNumber { get; set; }
    }
    
    public interface IParamParser //at client
    {
       //I do not know what object[] paramz is; I leave that to you; 
       //may be it needs encapsulation as well
       bool Parse(object[] paramz, Param p);
    }
    public interface IParamCreator //at server
    {
       Param CreateParams(int recordId, int transToPropId, int receivedViaTypeId, 
                          string recordNumber);
    }

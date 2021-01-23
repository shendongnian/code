    public void InsertIntoBaseElemList<IElem>(ref List<IElem> List, IElem Element)
    public interface IElem
    {
        int Position {get; set; }
    }
    public class XElem : IElem
    

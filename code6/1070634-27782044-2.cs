    public interface IElem
    {
        int Position {get; set; }
    }
    public class XElem : IElem ...
    public void InsertIntoBaseElemList(ref List<IElem> List, IElem Element)
    

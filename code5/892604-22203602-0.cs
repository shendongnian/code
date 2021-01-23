    public class Element
    {
        public List<Element> ParentList;
    
        public Element(int value, List<Element> parent)
        {
            ...
            ParentList = parent;
        }
    }

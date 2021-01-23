    public void InsertIntoBaseElemList<T>(List<T> List, T Element) where T : BaseElem
    {
        var index = List.FindIndex(i => i.Position > Element.Position);
        if (index < 0) // no item found
            List.Add(Element);
        else
            List.Insert(index, Element);
    }

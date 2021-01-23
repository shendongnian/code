    public void InsertIntoBaseElemList<T>(List<T> List, T Element) where T : IElem
    {
        int index = List.Count - 1;
        if (List[index].Position < Element.Position)
            List.Add(Element);
        else if (List[index].Position > Element.Position)
            List.Insert(index, Element);
    }

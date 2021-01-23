    public void InsertIntoBaseElemList<T>(ref List<T> List, T Element) where T : IElem
    {
        for (int index = List.Count - 1; index < List.Count; index++)
        {
            if (List[index].Position < Element.Position && index + 1 == List.Count)
                List.Add(Element);
            else if (List[index].Position > Element.Position)
                List.Insert(index, Element);
        }
    }

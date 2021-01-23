    public void InsertIntoBaseElemList<T>(List<T> List, T Element) where T : IElem
    {
        for (int index = 0; index < List.Count; index++)
        {
            if (List[index].Position < Element.Position && index + 1 == List.Count)
                List.Add(Element);
            else if (List[index].Position > Element.Position)
                List.Insert(index, Element);
        }
    }

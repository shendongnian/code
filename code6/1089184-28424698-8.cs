        public static void ReorderDefaultNamespaceToBeginning(XElement xElement)
        {
            var attrArray = xElement.Attributes().ToArray();
            int defaultIndex = -1;
            for (int i = 0; i < attrArray.Length && defaultIndex == -1; i++)
            {
                var attr = attrArray[i];
                if (attr.Name == XName.Get("xmlns", string.Empty))
                    defaultIndex = i;
            }
            if (defaultIndex < 0)
                return; // No default namespace
            int firstIndex = -1;
            for (int i = 0; i < attrArray.Length && firstIndex == -1; i++)
            {
                if (i == defaultIndex)
                    continue;
                var attr = attrArray[i];
                if (attr.Name.NamespaceName == "http://www.w3.org/2000/xmlns/"
                    && attr.Value == attrArray[defaultIndex].Value)
                    firstIndex = i;
            }
            if (defaultIndex != -1 && firstIndex != -1 && defaultIndex > firstIndex)
            {
                foreach (var attr in attrArray)
                    attr.Remove();
                attrArray.Swap(defaultIndex, firstIndex);
                foreach (var attr in attrArray)
                    xElement.Add(attr);
            }
        }
    public static class ListHelper
    {
        public static void Swap<T>(this T[] list, int i, int j)
        {
            if (i != j)
            {
                T temp = list[i];
                list[i] = list[j];
                list[j] = temp;
            }
        }
    }

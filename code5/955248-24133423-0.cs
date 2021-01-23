    public static class XmlExtensions{
         public static void SortChildren(tihs XmlNode node){
              node.ChildNodes.Sort((x, y) => x.Name.CompareTo(y.Name));
              node.ChildNodes.ForEach(x => x.SortChildren());
         }
    }

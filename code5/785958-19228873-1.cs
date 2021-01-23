    XElement root = XElement.Parse(strSerializedoutput);
    Dictionary<int, Pair> list = root.Descendants("item")
                                     .ToDictionary(x => (int) x.Attribute("id"),
                                      x => {
                                var pId = x.Parent.Attribute("id");
                                var depthLevel = x.Attribute("level");
                                return pId == null ? new Pair { parentID = 0, level = (int)depthLevel } :
                                new Pair { parentID = (int)pId, level = (int)depthLevel };
                              });
    public class Pair
    {
        public int parentID;
        public int level;
    }

            string jsonString = "your json string here";
            string rootName = "root", nodeName = "node";
            JContainer json;
            try {
                if (jsonString.StartsWith("["))
                {
                    json = JArray.Parse(jsonString);
                    treeView1.Nodes.Add(Utilities.Json2Tree((JArray)json, rootName, nodeName));
                }
                else
                {
                    json = JObject.Parse(jsonString);
                    treeView1.Nodes.Add(Utilities.Json2Tree((JObject)json, text));
                }
            }
            catch(JsonReaderException jre)
            {
                MessageBox.Show("Invalid Json.");
            }
    public class Utilities
    {
        public static TreeNode Json2Tree(JArray root, string rootName = "", string nodeName="")
        {
            TreeNode parent = new TreeNode(rootName);
            int index = 0;
            foreach(JToken obj in root)
            {
                TreeNode child = new TreeNode(string.Format("{0}[{1}]", nodeName, index++));
                foreach (KeyValuePair<string, JToken> token in (JObject)obj)
                {
                    switch (token.Value.Type)
                    {
                        case JTokenType.Array:
                        case JTokenType.Object:
                            child.Nodes.Add(Json2Tree((JObject)token.Value, token.Key));
                            break;
                        default:
                            child.Nodes.Add(GetChild(token));
                            break;
                    }
                }
                parent.Nodes.Add(child);
            }
            return parent;
        }
        public static TreeNode Json2Tree(JObject root, string text = "")
        {
            TreeNode parent = new TreeNode(text);
            foreach (KeyValuePair<string, JToken> token in root)
            {
                switch (token.Value.Type)
                {
                    case JTokenType.Object:
                        parent.Nodes.Add(Json2Tree((JObject)token.Value, token.Key));
                        break;
                    case JTokenType.Array:
                        int index = 0;
                        foreach(JToken element in (JArray)token.Value)
                        {
                            parent.Nodes.Add(Json2Tree((JObject)element, string.Format("{0}[{1}]", token.Key, index++)));
                        }
                        if (index == 0) parent.Nodes.Add(string.Format("{0}[ ]", token.Key)); //to handle empty arrays
                        break;
                    default:
                        parent.Nodes.Add(GetChild(token));
                        break;
                }
            }
            return parent;
        }
        private static TreeNode GetChild(KeyValuePair<string, JToken> token)
        {
            TreeNode child = new TreeNode(token.Key);
            child.Nodes.Add(string.IsNullOrEmpty(token.Value.ToString()) ? "n/a" : token.Value.ToString());
            return child;
        }
    }

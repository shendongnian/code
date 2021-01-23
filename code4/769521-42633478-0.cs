            string jsonString = "your json string here";
            string text = "root";
            JContainer json;
            try {
                if (jsonString.StartsWith("["))
                {
                    json = JArray.Parse(jsonString);
                    treeView1.Nodes.Add(Utilities.Json2Tree((JArray)json, text));
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
        public static TreeNode Json2Tree(JArray root, string text = "")
        {
            TreeNode parent = new TreeNode();
            if (!string.IsNullOrEmpty(text)) parent.Text = text;
            foreach(JToken obj in root)
            {
                foreach (KeyValuePair<string, JToken> token in (JObject)obj)
                {
                    switch (token.Value.Type)
                    {
                        case JTokenType.Array:
                        case JTokenType.Object:
                            parent.Nodes.Add(Json2Tree((JObject)token.Value, token.Key));
                            break;
                        default:
                            TreeNode child = new TreeNode(token.Key);
                            child.Nodes.Add(string.IsNullOrEmpty(token.Value.ToString()) ? "n/a" : token.Value.ToString());
                            parent.Nodes.Add(child);
                            break;
                    }
                }
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
                        TreeNode child = new TreeNode(token.Key);
                        child.Nodes.Add(string.IsNullOrEmpty(token.Value.ToString()) ? "n/a" : token.Value.ToString());
                        parent.Nodes.Add(child);
                        break;
                }
            }
            return parent;
        }
    }

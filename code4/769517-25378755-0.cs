    public class JsonTag
    {
        public JsonTag(JsonReader reader)
        {
            TokenType = reader.TokenType;
            Value = reader.Value;
            ValueType = reader.ValueType;
        }
        public JsonToken TokenType { get; set; }
        public object Value { get; set; }
        public Type ValueType { get; set; }
    }
    private void JsonToTreeview(string json)
	{
		tvwValue.BeginUpdate();
		var parentText = string.Empty;
		TreeNodeCollection parentNodes = tvwValue.Nodes;
		TreeNode current = null;
		tvwValue.Nodes.Clear();
		var reader = new JsonTextReader(new StringReader(json));
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
				case JsonToken.None:
					break;
				case JsonToken.StartObject:
					current = new TreeNode("{}") { Tag = new JsonTag(reader) };
					parentNodes.Add(current);
					parentNodes = current.Nodes;
					break;
				case JsonToken.StartArray:
					current = new TreeNode("[]") { Tag = new JsonTag(reader) };
					parentNodes.Add(current);
					if (current.PrevNode != null)
					{
						if (((JsonTag)current.PrevNode.Tag).TokenType == JsonToken.PropertyName)
							current.Parent.Text += "[]";
						parentText = current.Parent.Text;
						if (current.Parent.Parent.Text.Length > 2)
							parentText = ", " + parentText;
						current.Parent.Parent.Text = current.Parent.Parent.Text.Insert(current.Parent.Parent.Text.Length - 1, parentText);
					}
					parentNodes = current.Nodes;
					break;
				case JsonToken.StartConstructor:
					break;
				case JsonToken.PropertyName:
					current = new TreeNode("\"" + reader.Value + "\" : ");
					parentNodes.Add(current);
					if (current.PrevNode != null)
						current.PrevNode.Text += ",";
					parentNodes = current.Nodes;
					current = new TreeNode(reader.Value.ToString()) { Tag = new JsonTag(reader) };
					parentNodes.Add(current);
					break;
				case JsonToken.Comment:
					break;
				case JsonToken.Raw:
					break;
				case JsonToken.Date:
				case JsonToken.Integer:
				case JsonToken.Float:
				case JsonToken.Boolean:
				case JsonToken.String:
					var readerValue = "";
					if (reader.TokenType == JsonToken.String)
						readerValue = "\"" + reader.Value + "\"";
					else
						readerValue = reader.Value.ToString();
					current = new TreeNode(readerValue) { Tag = new JsonTag(reader) };
					parentNodes.Add(current);
					current.Parent.Text += readerValue;
					parentText = current.Parent.Text;
					if (current.Parent.Parent.Text.Length > 2)
						parentText = ", " + parentText;
					current.Parent.Parent.Text = current.Parent.Parent.Text.Insert(current.Parent.Parent.Text.Length - 1, parentText);
					if (((JsonTag)current.PrevNode.Tag).TokenType == JsonToken.PropertyName)
						current = current.Parent;
					current = current.Parent;
					parentNodes = current.Nodes;
					break;
				case JsonToken.Bytes:
					break;
				case JsonToken.Null:
					break;
				case JsonToken.Undefined:
					break;
				case JsonToken.EndObject:
					if (current.FirstNode.Tag != null &&
						((JsonTag)current.FirstNode.Tag).TokenType == JsonToken.PropertyName)
						current = current.Parent;
					current = current.Parent;
					if (current == null)
						parentNodes = tvwValue.Nodes;
					else
						parentNodes = current.Nodes;
					break;
				case JsonToken.EndArray:
					if (((JsonTag)current.PrevNode.Tag).TokenType == JsonToken.PropertyName)
						current = current.Parent;
					current = current.Parent;
					if (current == null)
						parentNodes = tvwValue.Nodes;
					else
						parentNodes = current.Nodes;
					break;
				case JsonToken.EndConstructor:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		tvwValue.EndUpdate();
	}

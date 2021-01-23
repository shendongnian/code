        private object FindRoot(string content)
        {
            var data = (IDictionary<string, object>)SimpleJson.DeserializeObject(content);
            if (RootElement.HasValue() && data.ContainsKey(RootElement))
            {
                return data[RootElement];
            }
            return data;
        }

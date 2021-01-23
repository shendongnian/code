        protected void OnGatheringNodeData(object sender, IndexingNodeDataEventArgs e)
        {
            var builder = new StringBuilder();
            foreach (var entry in e.Fields)
            {
                builder.AppendFormat("{0}, ", entry.Value);
            }
            e.Fields.Add("combinedText", builder.ToString());
        }

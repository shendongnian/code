            class WorkItem
            {
                public string Uri { get; set; }
                public byte[] Data { get; set; }
            }
            var items = new List<WorkItem>();
            // first do the parsing as you parsing 
            foreach (var urlFound in yourXmlDoc)
            {
                items.Add(new WorkItem{Uri = url});
            }
            // then the actual work itself
            Parallel.ForEach(items, item => {
                item.Data = GetUrlData(item.Uri);
            });

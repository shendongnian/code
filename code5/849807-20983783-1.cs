        internal static XmlRpcPost Post(Post input)
        {
            return new XmlRpcPost
            {
                categories = input.Categories,
                dateCreated = input.DateCreated,
                description = input.Body,
                mt_keywords = input.Tags == null ? null : String.Join(",", input.Tags),
                postid = input.PostID,
                title = input.Title,
                permaLink = input.Permalink,
                post_type = input.PostType,
                custom_fields = input.CustomFields == null ? null : input.CustomFields.Select(cf => new XmlRpcCustomField()
                {
                    id = cf.ID,
                    key = cf.Key,
                    value = cf.Value
                }).ToArray(),
                terms = input.Terms == null ? null : input.Terms.Select(t => new XmlRpcTerm()
                {
                    taxonomy = t.Taxonomy,
                    terms = t.Terms
                }).ToArray()
            };
        }

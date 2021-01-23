      /// <summary>
            /// Gets or sets collection of documents.
            /// </summary>
            [JsonConverter(typeof(IDWriteListConverter))]
            public ICollection<Document> Documents { get; set; }
    
            /// <summary>
            /// Gets or sets collection of comments.
            /// </summary>
            [JsonConverter(typeof(IDWriteListConverter))]
            public ICollection<Comment> Comments { get; set; }
    
            /// <summary>
            /// Gets or sets the collection of transactions.
            /// </summary>
            [JsonConverter(typeof(IDWriteListConverter))]
            public virtual ICollection<Transaction> Transactions { get; set; }

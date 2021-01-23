    new Hyperlinq(() => {
                "do log work here".Dump();
                using (var command = this.Connection.CreateCommand())
				{
				    // Usual command logic here
				}
             }, "Run Query").Dump();

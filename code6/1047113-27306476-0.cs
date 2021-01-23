    new Hyperlinq(() => {
                    "do log work here".Dump();
                    this.ExecuteQuery<string>(generatedSelect).Dump("Results");
                    this.ExecuteCommand(generatedCommand).Dump("Results");
                 }, "Run Query").Dump();

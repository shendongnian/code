            var update = Update
                .Set("Information.$.Heights", new BsonArray(new int[0]))
                .Set("Information.$.Colors", new BsonArray(new int[0]))
                .Set("Information.$.Widths", new BsonArray(new int[0]));
            var q = Query.Exists("Information.Heights"); // important
            c.Update(q, update, UpdateFlags.Multi);

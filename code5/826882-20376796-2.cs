            public bool GetNotesList(int pLexCodeId)
        {
            ListDictionary parameters = new ListDictionary();
            parameters.Add(Parameters.LexCodeId, pLexCodeId);
            return base.LoadFromSql("[" + this.SchemaStoredProcedure + "Custom_GetNotesList]", parameters);
        }

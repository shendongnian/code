        Word.Range rng = this.Content;
        rng.Find.MatchWildcards = true;
        rng.Find.Text = "[<]*[>]";
        while (rng.Find.Execute())
        {
            // create a local Range containing only a single found string
            object cstart = rng.Start;
            object cend   = rng.End;
            Word.Range localrng = this.Range(ref cstart, ref cend);
            // replace the text with a custom DocProperty
            Word.Field newfld = localrng.Fields.Add(localrng, Word.WdFieldType.wdFieldDocProperty, "MyDocProp", false);
            localrng.Fields.Update();
        }

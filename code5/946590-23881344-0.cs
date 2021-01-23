            var terms = SharePointHelper.GetTaxonomyTerms(webUrl, libraryTitle, fieldTitle);
            var term = terms.AsRootTreeViewTerm();
            ....
        }
        public static Term AsRootTreeViewTerm(this SP.TermCollection spTerms)
        {
            var root = new Term();
            foreach (SP.Term spTerm in spTerms)
            {
                List<string> names = spTerm.PathOfTerm.Split(';').ToList();
                var term = BuildTerm(root.Terms, names);
                if (!root.Terms.Contains(term))
                    root.Terms.Add(term);
            }
            return root;
        }
        static Term BuildTerm(IList<Term> terms, List<string> names)
        {
            Term term = terms.Where(x => x.Name == names.First())
                             .DefaultIfEmpty(new Term() { Name = names.First() })
                             .First();
            names.Remove(names.First());
            if (names.Count > 0)
            {
                Term child = BuildTerm(term.Terms, names);
                if (!term.Terms.Contains(child))
                    term.Terms.Add(child);
            }
            return term;
        }

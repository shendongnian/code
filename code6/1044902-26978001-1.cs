	//return the date/time when the client was last used to create a workorder
        public ICollection<ClientLastUsed> GetLastUsed(string ClientID)
        {
            var finalResults = new List<ClientLastUsed>();
            using (ISession session = SessionHelper.OpenSession())
            {
                var results = session
                    .GetNamedQuery("GetClientLastUsed")
                    .SetParameter("ClientID", ClientID)
                    .SetResultTransformer(Transformers.AliasToBean<ClientLastUsed>()).List<ClientLastUsed>();
                finalResults = results as List<ClientLastUsed>;
            }
            return finalResults;
        }

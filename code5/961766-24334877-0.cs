        public string GetManagerName(DirectoryEntry dirEntry)
        {
            DirectoryEntry DomainRoot = AD.GetDirectoryEntry();
            using (DirectorySearcher search = new DirectorySearcher())
            {
                search.SearchRoot = DomainRoot;
                search.Filter = "(&(distinguishedName=" + Convert.ToString(dirEntry.Properties["manager"][0]) + "))";
                SearchResult result = search.FindOne();
                if (result != null)
                {
                    using (DirectoryEntry mgr = result.GetDirectoryEntry())
                    {
                        return mgr.Name.Substring(3);
                    }
                }
                return string.Empty;
            }
        }

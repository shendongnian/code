    public async Task<ActionResult> AjaxStuff()
    {
        var c = new LdapConnection(string.Empty);
        var result1 = await c.SendRequestAsync(new SearchRequest(string.Empty, "(&(objectClass=*))", SearchScope.Base, "defaultNamingContext"), PartialResultProcessing.NoPartialResultSupport);
        var nc = ((SearchResponse)result1).Entries[0].Attributes["defaultNamingContext"][0].ToString();
        var result2 = (SearchResponse)(await c.SendRequestAsync(new SearchRequest(nc, "(&(givenName=steve))", SearchScope.Subtree), PartialResultProcessing.NoPartialResultSupport)));
        var dn = result2.Entries.Count > 0 ? result2.Entries[0].DistinguishedName : "no such thing";
        return this.PartialView("AjaxStuff", dn);
    }

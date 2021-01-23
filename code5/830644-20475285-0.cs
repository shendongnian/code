            var solrConnectionProducts = new SolrConnection(SolrServerUrl + "/products");
            Startup.Init<SolrProductDocument>(solrConnectionProducts);
           
            var solrConnectionProducts2 = new SolrConnection(SolrServerUrl + "/products2");
            Startup.Init<SolrProductDocument>(solrConnectionProducts2);

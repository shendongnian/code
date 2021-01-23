    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using SolrNet;
    using SolrNet.Commands.Parameters;
    using SolrNet.DSL;
    using SolrNet.Exceptions;
    using SolrNet.Impl;
    
    public class Class1
    {
        public void Method1()
        {
            var serviceProvider = ((IServiceProvider)Startup.Container);
            if (serviceProvider == null)
                return;
    
            var solrOperation = serviceProvider.GetService(typeof(ISolrReadOnlyOperations<MySampleItem>));
            if (solrOperation == null)
                return;
    
            ISolrReadOnlyOperations<MySampleItem> solr = (ISolrReadOnlyOperations<MySampleItem>)solrOperation;
            SearchParameters parameters = new SearchParameters();
            parameters.FreeSearch = txtSearch.Text;
            DateTime currentdate = DateTime.Now;
            var facetweek = new SolrQueryByRange<DateTime?>("date", new DateTime(currentdate.Year, currentdate.Month, currentdate.Day).AddDays(-7), new DateTime(currentdate.Year, currentdate.Month, currentdate.Day));
            var facetyear = new SolrQueryByRange<DateTime?>("date", new DateTime(currentdate.Year, currentdate.Month, currentdate.Day).AddYears(-1), new DateTime(currentdate.Year, currentdate.Month, currentdate.Day));
            var facetmonth = new SolrQueryByRange<DateTime?>("date", new DateTime(currentdate.Year, currentdate.Month, currentdate.Day).AddMonths(-1), new DateTime(currentdate.Year, currentdate.Month, currentdate.Day));
            var start = (parameters.PageIndex - 1) * parameters.PageSize;
            var matchingRecords = solr.Query(BuildQuery(parameters), new QueryOptions
            {
    
                ExtraParams = new Dictionary<string, string>
                {
                    {"fq", "-type file)  roles 1)"},
                    {"group.truncate","true"},
                },
                Highlight = new HighlightingParameters { },
                Grouping = new GroupingParameters()
                {
                    Fields = new[] { "collapse" },
                    Ngroups = true,
                },
                FilterQueries = BuildFilterQueries(parameters),
                Rows = parameters.PageSize,
                Facet = new FacetParameters
                {
                    Queries = new ISolrFacetQuery[]
                    {   
                        new SolrFacetFieldQuery("category") { MinCount = 0 ,Limit=12,Offset=0,Sort=true},
                        new SolrFacetFieldQuery("user") { MinCount = 1 ,Limit=12,Offset=0,Sort=true},
                        new SolrFacetFieldQuery("group") { MinCount = 1 ,Limit=12,Offset=0,Sort=true},
                        new SolrFacetFieldQuery("tag") { MinCount = 1 ,Limit=12,Offset=0,Sort=true},
                        new SolrFacetQuery(facetweek),
                        new SolrFacetQuery(facetyear),
                        new SolrFacetQuery(facetmonth),
                    }
                },
            });
        }
    
        public ISolrQuery BuildQuery(SearchParameters parameters)
        {
            if (!string.IsNullOrEmpty(parameters.FreeSearch))
            {
                return new LocalParams { { "boost b", "sum(contentscore,1)" }, { "defType", "edismax" } } + new SolrQuery(parameters.FreeSearch);
                //return new SolrQuery(parameters.FreeSearch);
            }
            return SolrQuery.All;
        }
    
        public ICollection<ISolrQuery> BuildFilterQueries(SearchParameters parameters)
        {
            var queriesFromFacets = from p in parameters.Facets
                                    select (ISolrQuery)Query.Field(p.Key).Is(p.Value);
            return queriesFromFacets.ToList();
        }
    }

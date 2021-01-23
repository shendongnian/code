    using Sitecore.ContentSearch;
    using Sitecore.ContentSearch.Converters;
    using Sitecore.ContentSearch.SearchTypes;
    using System;
    using System.ComponentModel;
    
    namespace YourNamespace
    {
        public class DateSearchResultItem : SearchResultItem
        {
            [IndexField("startdate"), TypeConverter(typeof(IndexFieldDateTimeValueConverter))]
            public DateTime StartDate { get; set; }
    
            [IndexField("enddate"), TypeConverter(typeof(IndexFieldDateTimeValueConverter))]
            public DateTime EndDate { get; set; }
        }
    }

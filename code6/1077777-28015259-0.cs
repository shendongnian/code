    using System.Collections.Generic;
    using System.Runtime.Serialization;
    public interface IPaginatedFilter {
        int DefaultLimit { get; }
        int MaximumLimit { get; }
        List<string> SupportedOrderBy { get; }
        bool IsAscendingByDefault { get; }
    }
    [DataContract]
    public sealed class PaginationInput 
    {
        [DataMember(Name = "limit", Order = 2)]
        public int Limit { get; set; }
        [DataMember(Name = "offset", Order = 3)]
        public int Offset { get; set; }
        [DataMember(Name = "orderBy", Order = 4)]
        public string OrderBy { get; set; }
        [DataMember(Name = "orderByDirection", Order = 5)]
        public string OrderByDirection { get; set; }
    }
    /// <summary>
    ///     Base search filter
    /// </summary>
    public class SearchBase {
        /// <summary>
        ///     Results page information
        /// </summary>
        [DataMember(Name = "page", Order = 1)]
        public PaginationInput Page { get; set; }
        /// <summary>
        ///     Search phrase applicable to any member of the inheriting search filter
        /// </summary>
        [DataMember(Name = "any", Order = 1)]
        public string Any { get; set; }
    }
    public class EntitySearchCriteria : SearchBase, IPaginatedFilter {
        // columns to provide search functions for
        #region Implementation of IPaginatedFilter
        public int DefaultLimit {
            get { return 20; }
        }
        public int MaximumLimit {
            get { return 50; }
        }
        public List<string> SupportedOrderBy {
            get { return new List<string>
            {
                // columns that support ordering
            }; }
        }
        public bool IsAscendingByDefault {
            get { return true; }
        }
        #endregion
    }

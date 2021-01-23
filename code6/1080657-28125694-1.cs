    /// <summary>
    /// Condition Filter
    /// </summary>
    public class ConditionFilter
    {
        /// <summary>
        /// Oscar Winner
        /// </summary>
        public bool? OscarWinner { get; set; }
        /// <summary>
        /// Page you want to get. Counting from 0.
        /// </summary>
        public int? Page { get; set; }
        /// <summary>
        /// Number of jobs on page. Default page size 1000.
        /// </summary>
        public int? PageSize { get; set; }
    }

    /// <summary>
    /// <para>MSSQL class</para>
    /// </summary>
    public class MSSQL
    {
        #region Class field declaration
        private string f_connectionString;
        #endregion
    
        #region Public method
    
        /// <summary>
        /// <para>Static method for getting the class instance.</para>
        /// </summary>
        /// <param name="p_connectionString">MSSQL connection string</param>
        /// <returns><see cref="MSSQL"/></returns>
        public static MSSQL Create(string p_connectionString)
        {
            return new MSSQL(p_connectionString);
        }
    
        public void SiteCollection(string p_siteCollectionName)
        {
            //Your Logic here.
        }
    
        #endregion
    
    
        #region Constructor
        /// <summary>
        /// <para>Hide the default constructor</para>
        /// </summary>
        private MSSQL()
        {
    
        }
    
        /// <summary>
        /// <para>Private constructor for Static method</para>
        /// </summary>
        /// <param name="p_connectionString">MSSQL connection string</param>
        private MSSQL(string p_connectionString)
        {
            this.f_connectionString = p_connectionString;
        }
        #endregion
    }

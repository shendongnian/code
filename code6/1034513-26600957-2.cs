    const string _shopEndpoint = "/admin/shop.json";
    const string _shopifyHost = ".myshopify.com";
    class ShopResult
    {
        public Shop Shop { get; set; }
    }
    /// <summary>
    /// The Shopify API's shop object is a collection of the general settings and information about the shop.
    /// </summary>
    public class Shop
    {
        /// <summary>
        /// The shop's street address.
        /// </summary>
        public string Address1 { get; set; }
    
        /// <summary>
        /// The city in which the shop is located.
        /// </summary>
        public string City { get; set; }
    
        /// <summary>
        /// The shop's country (by default equal to the two-letter country code).
        /// </summary>
        public string Country { get; set; }
    
        /// <summary>
        /// The two-letter country code corresponding to the shop's country.
        /// </summary>
        public string CountryCode { get; set; }
    
        /// <summary>
        /// The shop's normalized country name.
        /// </summary>
        public string CountryName { get; set; }
    
        /// <summary>
        /// The date and time when the shop was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    
        /// <summary>
        /// The customer's email.
        /// </summary>
        public string CustomerEmail { get; set; }
    
        /// <summary>
        /// The three-letter code for the currency that the shop accepts.
        /// </summary>
        public string Currency { get; set; }
    
        /// <summary>
        /// The shop's domain.
        /// </summary>
        public string Domain { get; set; }
            
        /// <summary>
        /// The contact email address for the shop.
        /// </summary>
        public string Email { get; set; }
            
        /// <summary>
        /// Feature is present when a shop has a google app domain. It will be returned as a URL. If
        /// the shop does not have this feature enabled it will default to "null."
        /// </summary>
        public string GoogleAppsDomain { get; set; }
    
        /// <summary>
        /// Feature is present if a shop has google apps enabled. Those shops with this feature
        /// will be able to login to the google apps login. Shops without this feature enabled will default to "null."
        /// </summary>
        public string GoogleAppsLoginEnabled { get; set; }
    
        /// <summary>
        /// A unique numeric identifier for the shop.
        /// </summary>
        public int Id { get; set; }
    
        /// <summary>
        /// Geographic coordinate specifying the north/south location of a shop.
        /// </summary>
        public string Latitude { get; set; }
    
        /// <summary>
        /// Geographic coordinate specifying the east/west location of a shop.
        /// </summary>
        public string Logitude { get; set; }
    
        /// <summary>
        /// A string representing the way currency is formatted when the currency isn't specified.
        /// </summary>
        public string MoneyFormat { get; set; }
    
        /// <summary>
        /// A string representing the way currency is formatted when the currency is specified.
        /// </summary>
        public string MoneyWithCurrencyFormat { get; set; }
    
        /// <summary>
        /// The shop's 'myshopify.com' domain.
        /// </summary>
        public string MyshopifyDomain { get; set; }
    
        /// <summary>
        /// The name of the shop.
        /// </summary>
        public string Name { get; set; }
    
        /// <summary>
        /// The name of the Shopify plan the shop is on.
        /// </summary>
        public string PlanName { get; set; }
            
        /// <summary>
        /// The display name of the Shopify plan the shop is on.
        /// </summary>
        public string DisplayPlanName { get; set; }
    
        /// <summary>
        /// Indicates whether the Storefront password protection is enabled.
        /// </summary>
        public string PasswordEnabled { get; set; }
    
        /// <summary>
        /// The contact phone number for the shop.
        /// </summary>
        public string Phone { get; set; }
    
        /// <summary>
        /// The shop's normalized province or state name.
        /// </summary>
        public string Province { get; set; }
    
        /// <summary>
        /// The two-letter code for the shop's province or state.
        /// </summary>
        public string ProvinceCode { get; set; }
    
        /// <summary>
        /// The username of the shop owner.
        /// </summary>
        public string ShopOwner { get; set; }
    
        /// <summary>
        /// The setting for whether applicable taxes are included in product prices: Valid values are: "true" or "null."
        /// </summary>
        public string TaxShipping { get; set; }
    
        /// <summary>
        /// The setting for whether applicable taxes are included in product prices. Valid values are: "true" or "null."
        /// </summary>
        public string TaxesIncluded { get; set; }
    
        /// <summary>
        /// The setting for whether the shop is applying taxes on a per-county basis or not (US-only). Valid values are: "true" or "null."
        /// </summary>
        public string CountyTaxes { get; set; }
    
        /// <summary>
        /// The name of the timezone the shop is in.
        /// </summary>
        public string Timezone { get; set; }
    
        /// <summary>
        /// The zip or postal code of the shop's address.
        /// </summary>
        public string Zip { get; set; }
    }

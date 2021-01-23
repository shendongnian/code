    using System;
    using System.Web;
    using System.Data;
    using System.Collections.Generic;
    
    using CMS.Ecommerce;
    using CMS.SettingsProvider;
    using CMS.SiteProvider;
    using CMS.GlobalHelper;
    
    /// <summary>
    /// Sample tax class info provider. 
    /// Can be registered either by replacing the TaxClassInfoProvider.ProviderObject (uncomment the line in SampleECommerceModule.cs) or through cms.extensibility section of the web.config
    /// </summary>
    public class CustomTaxClassInfoProvider : TaxClassInfoProvider
    {
        #region "Example: Custom taxes calculation"
    
        /// <summary>
        /// Returns DataSet with all the taxes which should be applied to the shopping cart items.
        /// </summary>
        /// <param name="cart">Shopping cart</param>
        protected override DataSet GetTaxesInternal(ShoppingCartInfo cart)
        {
            DataSet ds = new DataSet();
    
            // Create an empty taxes table
            DataTable table = GetNewTaxesTable();
    
            // Build taxes table 
            // ------------------------
            // Please note:         
            // Taxes table is built manually for the purpose of this example, however you can build it from the response of a tax calculation service as well.
            // All the data which might be required for the calculation service is stored in the ShoppingCartInfo object, e.g.:
            // - use AddressInfoProvider.GetAddresInfo(cart.ShoppingCartBillingAddressID) to get billing address info
            // - use AddressInfoProvider.GetAddresInfo(cart.ShoppingCartShippingAddressID) to get shipping address info        
            // etc.
            // ------------------------
            foreach (ShoppingCartItemInfo item in cart.CartItems)
            {
                // Get SKU properties
                string skuNumber = item.SKU.SKUNumber.ToLowerCSafe();
                int skuId = item.SKUID;
                
                switch (skuNumber)
                {
                    // Tax for product A (20%)
                    case "a":
                        AddTaxRow(table, skuId, "Tax A", 20);
                        break;
    
                    // Taxes for product B (11% and 10%)
                    case "b":
                        AddTaxRow(table, skuId, "Tax B1", 11);
                        AddTaxRow(table, skuId, "Tax B2", 10);
                        break;
    
                    // Zero tax for product C (0%)
                    case "c":
                        break;
    
                    // The same tax for all other products (5%)
                    default:
                        AddTaxRow(table, skuId, "Tax C", 5);
                        break;
    
                }
            }
    
            // Return built dataset with the taxes
            ds.Tables.Add(table);
            return ds;
        }
    
        #region "Private methods"
        
        /// <summary>
        /// Creates an empty taxes table.
        /// </summary>    
        private DataTable GetNewTaxesTable()
        {
            DataTable table = new DataTable();
    
            // Add required columns
            table.Columns.Add("SKUID", typeof(int));
            table.Columns.Add("TaxClassDisplayName", typeof(string));
            table.Columns.Add("TaxValue", typeof(double));
    
            // Add optional columns
            //table.Columns.Add("TaxIsFlat", typeof(bool));
            //table.Columns.Add("TaxIsGlobal", typeof(bool));
            //table.Columns.Add("TaxClassZeroIfIDSupplied", typeof(bool));
    
            return table;
        }
    
    
        /// <summary>
        /// Creates tax row which holds the data of the tax which should be applied to the given SKU.
        /// </summary>
        /// <param name="taxTable">Tax table the row should be added to.</param>
        /// <param name="skuId">SKU ID</param>
        /// <param name="taxName">Tax name</param>
        /// <param name="taxValue">Tax value</param>
        /// <param name="taxIsFlat">Indicates if the tax value is flat or relative. By default it is false (= relative tax)</param>
        /// <param name="taxIsGlobal">Indicates if the tax value is in global main currency or in site main currency. By default it is false (= tax value is in site main currency).</param>    
        /// <param name="taxIsGlobal">Indicates if the tax is zero if customer's registration ID is supplied. By default it is false (= tax is not zero if customer's tax registration ID is supplied).</param>    
        private void AddTaxRow(DataTable taxTable, int skuId, string taxName, double taxValue, bool taxIsFlat, bool taxIsGlobal, bool zeroTaxIfIDSupplied)
        {
            DataRow row = taxTable.NewRow();
    
            // Set required columns
            row["SKUID"] = skuId;
            row["TaxClassDisplayName"] = taxName;
            row["TaxValue"] = taxValue;
    
            // Set optional columns
            //row["TaxIsFlat"] = taxIsFlat;
            //row["TaxIsGlobal"] = taxIsGlobal;
            //row["TaxClassZeroIfIDSupplied"] = taxIsGlobal;
    
            taxTable.Rows.Add(row);
        }
    
    
        /// <summary>
        /// Creates tax row which holds the data of the tax which should be applied to the given SKU.
        /// </summary>
        /// <param name="taxTable">Tax table the row should be added to.</param>
        /// <param name="skuId">SKU ID</param>
        /// <param name="taxName">Tax name</param>
        /// <param name="taxValue">Tax value</param>
        private void AddTaxRow(DataTable taxTable, int skuId, string taxName, double taxValue)
        {
            AddTaxRow(taxTable, skuId, taxName, taxValue, false, false, false);
        }
    
        #endregion
    
        #endregion
    }

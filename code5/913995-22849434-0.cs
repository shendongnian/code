    public CamlQuery CreateInventoryQuery(string searchSku)
    {
       var qry = new CamlQuery();
       qry.ViewXml =
          @"<View>
             <Query>
              <Where>
                <BeginsWith>
                  <FieldRef Name='SKU' />
                  <Value Type='Text'>" + searchSku + @"</Value>
                </BeginsWith>
              </Where>
            </Query>
           </View>";
       return qry;
    }
 

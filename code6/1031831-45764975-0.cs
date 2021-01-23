    public async Task<String> ProcessAdditionalProductDetialsAsync(ItemType oItem) { 
        String additionalProductDetails = await.Task(() => {
           if (oItem.ItemSpecifics.Count > 0) {
              foreach (NameValueListType nvl in oItem.ItemSpecifics) { 
       
                 if (nvl.Value.Count > 0) {
                       string retval = String.Empty;
                       foreach (string s in nvl.Value) {
                           retval += "<li><strong>" 
                             + nvl.Name + ":</strong>&nbsp;" + s + "</li>";
                       }
                 }
              }
           }
           return retval;
         }
         return additionalProductDetails;
     }

    public async Task<String> ProcessAdditionalProductDetialsAsync(ItemType oItem)
    {
        return await Task.Run(() =>
        {
            String additionalProductDetails = string.Empty;
    
            if (oItem.ItemSpecifics.Count > 0)
            {
                foreach (NameValueListType nvl in oItem.ItemSpecifics)
                {
                    if (nvl.Value.Count > 0)
                    {
                        foreach (string s in nvl.Value)
                        {
                            additionalProductDetails += "<li><strong>" + nvl.Name + ":</strong>&nbsp;" + s + "</li>";
                        }
                    }
                }
            }
            return additionalProductDetails;
        });
    }

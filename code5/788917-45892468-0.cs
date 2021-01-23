        SPList mySPList = oWeb.Lists["ProjectList"];
    newItem["LookupFieldName"] = new SPFieldLookupValue(getLookUp(mySPList,LookupFieldValue), LookupFieldValue);
    
    
    
    public static int getLookUp(SPList oList, string FieldValue, string sFieldName="Title")
            {
    
                foreach (SPListItem spi in oList.GetItems())
                {
                    if (spi[sFieldName].ToString() == FieldValue)
                    {
                        return spi.ID;
                    }
                }
                return 0;
            }

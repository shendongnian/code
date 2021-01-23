        SelectCustomFieldRef selectCustFieldRef = customField as SelectCustomFieldRef;
        sCustFieldRefId = selectCustFieldRef.internalId;
        sCustFieldRefValue = NetSuite_getCustomListValueFromID(selectCustFieldRef.value.typeId, long.Parse(selectCustFieldRef.value.internalId));
        private string NetSuite_getCustomListValueFromID(string sCustomListInternalID, long lValue)
        {
            string sReturnValue = string.Empty;
            CustomList custList;
            if (NetSuite_TryGetCustomList(sCustomListInternalID, out custList))
            {
                CustomListCustomValue[] clValueList = custList.customValueList.customValue;
                foreach (CustomListCustomValue clValue in custList.customValueList.customValue)
                {
                    if (clValue.valueId == lValue)
                    {
                        sReturnValue = clValue.value;
                        break;
                    }
                }
            }
            return sReturnValue;
        }

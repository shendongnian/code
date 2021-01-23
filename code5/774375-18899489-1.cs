        // NetSuite Session
        // _service is constructed elsewhere in code.
        // Global Values
        Dictionary<string, CustomizationRef> _Dictionary_CustomListRef = new Dictionary<string, CustomizationRef>();
        Dictionary<string, CustomList> _Dictionary_CustomList = new Dictionary<string, CustomList>();
        Dictionary<string, TransactionBodyCustomField> _Dictionary_TransactionBodyCustomField = new Dictionary<string, TransactionBodyCustomField>();
        private CustomFieldRef NetSuite_CreateSelectCustomFieldRef(string sName, string sValue)
        {
            //List or Record Type reference
            SelectCustomFieldRef custbody_field = new SelectCustomFieldRef();
            custbody_field.internalId = sName;
            custbody_field.value = new ListOrRecordRef();
            // Get the Targeted List that we point to in NetSuite
            custbody_field.value.typeId = NetSuite_getTransactionBodyCustomFieldListInternalId(sName);
            // Get ID of List Value from our targeted list in NetSuite
            custbody_field.value.internalId = NetSuite_getCustomListValueID(custbody_field.value.typeId, sValue);
            return custbody_field;
        }
        private string NetSuite_getTransactionBodyCustomFieldListInternalId(string sID)
        {
            string sReturnValue = string.Empty;
            TransactionBodyCustomField tbCustomField = NetSuite_getTransactionBodyCustomField(sID);
            if (tbCustomField != null)
            {
                sReturnValue = tbCustomField.selectRecordType.internalId;
            }
            return sReturnValue;
        }
        private TransactionBodyCustomField NetSuite_getTransactionBodyCustomField(string sID)
        {
            TransactionBodyCustomField tbCustomField = null;
            if (!_Dictionary_TransactionBodyCustomField.TryGetValue(sID, out tbCustomField))
            {
                // Gets a specific custom body object
                CustomizationRef cref = new CustomizationRef();
                cref.internalId = sID;
                cref.scriptId = sID;
                cref.type = RecordType.transactionBodyCustomField;
                cref.typeSpecified = true;
                ReadResponse res = _service.get(cref);
                if (res.status.isSuccess)
                    tbCustomField = res.record as TransactionBodyCustomField;
                _Dictionary_TransactionBodyCustomField.Add(sID, tbCustomField);
            }
            return tbCustomField;
        }
        private bool NetSuite_TryGetCustomList(string sCustomListInternalID, out CustomList custList)
        {
            custList = null;
            bool bSuccess = false;
            if (!_Dictionary_CustomList.TryGetValue(sCustomListInternalID, out custList))
            {
                if (_Dictionary_CustomListRef.Count == 0)
                    initializeCustomListDictionary();
                CustomizationRef crCustomList = null;
                if (_Dictionary_CustomListRef.TryGetValue(sCustomListInternalID, out crCustomList))
                {
                    RecordRef recRef = new RecordRef();
                    recRef.internalId = crCustomList.internalId;
                    recRef.type = RecordType.customList;
                    recRef.typeSpecified = true;
                    ReadResponse readResp = _service.get(recRef);
                    if (readResp.status.isSuccess)
                        custList = readResp.record as CustomList;
                    _Dictionary_CustomList.Add(sCustomListInternalID, custList);
                }
            }
            if (custList == null)
                bSuccess = false;
            else
                bSuccess = true;
            return bSuccess;
        }
        private string NetSuite_getCustomListScriptID(string sCustomListInternalID)
        {
            string sReturnValue = string.Empty;
            CustomList custList;
            if (NetSuite_TryGetCustomList(sCustomListInternalID, out custList))
                sReturnValue = custList.scriptId;
            return sReturnValue;
        }
        private string NetSuite_getCustomListValueID(string sCustomListInternalID, string sValue)
        {
            string sReturnValue = string.Empty;
            CustomList custList;
            if (NetSuite_TryGetCustomList(sCustomListInternalID, out custList))
            {
                CustomListCustomValue[] clValueList = custList.customValueList.customValue;
                foreach(CustomListCustomValue clValue in custList.customValueList.customValue)
                {
                    if (clValue.value.ToUpper() == sValue.ToUpper())
                    {
                        sReturnValue = clValue.valueId.ToString();
                        break;
                    }
                }
            }
            return sReturnValue;
        }
        private void initializeCustomListDictionary()
        {
            _Dictionary_CustomListRef.Clear();
            // Gets all of the custom lists
            CustomizationType ct = new CustomizationType();
            ct.getCustomizationType = GetCustomizationType.customList;
            ct.getCustomizationTypeSpecified = true;
            GetCustomizationIdResult res = _service.getCustomizationId(ct, true);
            foreach (CustomizationRef cref in res.customizationRefList)
                _Dictionary_CustomListRef.Add(cref.internalId, cref);
        }

    [WebMethod]
    public CascadingDropDownNameValue[] GetBankList(
    string knownCategoryValues,
    string category,
    string contextKey
    )
    {
      selectedVal = LocateSelectedVal(contextKey)
    List<CascadingDropDownNameValue> values =
    new List<CascadingDropDownNameValue>();
    
    values.Add(new CascadingDropDownNameValue(
    "ICICI", 1001.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "AXIS", 1002.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "AMEX", 1003.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "HDFC", 1004.ToString(),  CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "OPUS", 1005.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "HSBC", 1006.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "SBI", 1007.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "ICICI-SHAKTI", 1008.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "CITI", 1009.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "CORP", 1010.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "HDFC-PRIZM", 1011.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "CUB", 1012.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "AXISB24", 1013.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "IDBI", 1014.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "LVB", 1015.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "MASHREQ", 1016.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "YES", 1017.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "FEDERAL", 1018.ToString(), CheckifSelected()));
    
    values.Add(new CascadingDropDownNameValue(
    "SBI87", 1019.ToString(), CheckifSelected()));
    
    return values.ToArray();

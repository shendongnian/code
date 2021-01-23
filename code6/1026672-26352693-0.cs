    <telerik:GridTemplateColumn>
        <%# GetColumn1Data() %>
    </telerik:GridTemplateColumn>
    
    public string GetColumn1Data()
    {
        return DataSet.Column1.ToString(); //pseudo code
    }

    @{
    var serializer = new DataContractJsonSerializer(typeof(DataTableItemModel));
    var memoryStream = new MemoryStream();
    serializer.WriteObject(memoryStream, Model.DataTablesDescription);
    @Html.Raw(new StreamReader(memoryStream).ReadToEnd())
    }

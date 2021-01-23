    public class DataTableModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var request = controllerContext.HttpContext.Request;
            var contentType = request.ContentType;
            if (!contentType.StartsWith("application/json", StringComparison.OrdinalIgnoreCase))
                return (null);
            request.InputStream.Seek(0, SeekOrigin.Begin);
            var bodyText = new StreamReader(request.InputStream).ReadToEnd();
            if (string.IsNullOrEmpty(bodyText)) return (null);
            var jsonObj = JObject.Parse(bodyText);
            var jArray = (JArray)jsonObj["aoData"];
            var tableValueCollection = jArray.Select(x => new { Name = x["name"].Value<string>(), Value = x["value"].Value<string>() }).ToDictionary(x => x.Name, x => x.Value);
            var numberOfColumns = int.Parse(tableValueCollection["iColumns"], CultureInfo.InvariantCulture);
            var columns = new List<string>();
            for (int i = 0; i < numberOfColumns; i++)
            {
                var queryParamName = string.Format("mDataProp_{0}", i.ToString(CultureInfo.InvariantCulture));
                columns.Add(tableValueCollection[queryParamName]);
            }
            var numberOfSortingColumns = int.Parse(tableValueCollection["iSortingCols"], CultureInfo.InvariantCulture);
            var sortingColumns = new List<DataTableRequest.SortBy>();
            for (int i = 0; i < numberOfSortingColumns; i++)
            {
                var sortColQueryParamName = string.Format("iSortCol_{0}", i.ToString(CultureInfo.InvariantCulture));
                if (tableValueCollection[sortColQueryParamName] != null)
                {
                    var sortDirQueryParamName = string.Format("sSortDir_{0}", i.ToString(CultureInfo.InvariantCulture));
                    var sortingDirection = tableValueCollection[sortDirQueryParamName];
                    var sortingColumnIndex = int.Parse(tableValueCollection[sortColQueryParamName], CultureInfo.InvariantCulture);
                    var sortingColumnName = columns[sortingColumnIndex];
                    sortingColumns.Add(new DataTableRequest.SortBy(sortingColumnName, sortingDirection));
                }
            }
            var displayStart = int.Parse(tableValueCollection["iDisplayStart"], CultureInfo.InvariantCulture);
            var displayLength = int.Parse(tableValueCollection["iDisplayLength"], CultureInfo.InvariantCulture);
            var pageSize = displayLength;
            var pageIndex = displayStart / displayLength;
            string search = null;
            if (tableValueCollection.ContainsKey("sSearch"))
            {
                search = tableValueCollection["sSearch"];
            }
            
            var sEcho = int.Parse(tableValueCollection["sEcho"], CultureInfo.InvariantCulture);
            var dataTableRequest = new DataTableRequest(pageIndex, pageSize, search, sortingColumns, sEcho);
            return dataTableRequest;
        }
    }

    /// <summary>
    /// Model Binder for DataTablesParameterModel
    /// </summary>
    public class DTModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            base.BindModel(controllerContext, bindingContext);
            HttpRequestBase request = controllerContext.HttpContext.Request;
            // Retrieve request data
            int draw = Convert.ToInt32(request["draw"]);
            int start = Convert.ToInt32(request["start"]);
            int length = Convert.ToInt32(request["length"]);
            // Search
            DTSearch search = new DTSearch
            {
                Value = request["search[value]"],
                Regex = Convert.ToBoolean(request["search[regex]"])
            };
            // Order
            var o = 0;
            var order = new List<DTOrder>();
            while (request["order[" + o + "][column]"] != null)
            {
                order.Add(new DTOrder()
                {
                    Column = Convert.ToInt32(request["order[" + o + "][column]"]),
                    Dir = request["order[" + o + "][dir]"]
                });
                o++;
            }
            // Columns
            var c = 0;
            var columns = new List<DTColumn>();
            while (request["columns[" + c + "][name]"] != null)
            {
                columns.Add(new DTColumn
                {
                    Data = request["columns[" + c + "][data]"],
                    Name = request["columns[" + c + "][name]"],
                    Orderable = Convert.ToBoolean(request["columns[" + c + "][orderable]"]),
                    Search = new DTSearch
                    {
                        Value = request["columns[" + c + "][search][value]"],
                        Regex = Convert.ToBoolean(request["columns[" + c + "][search][regex]"])
                    }
                });
                c++;
            }
            return new DTParameterModel
            {
                Draw = draw,
                Start = start,
                Length = length,
                Search = search,
                Order = order,
                Columns = columns
            };
        }
    }

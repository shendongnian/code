        public class DynamicQueryResult
        {
            public dynamic QueryResults {get; set;}
        }
    Then in your MVC View:
        @model Namespace.DynamicQueryResult
        @Html.Partial("~/link/to/_partialView.cshtml", Model)

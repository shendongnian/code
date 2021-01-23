    public class WorkItemViewModel 
    {
        public Int64 ID { get; set; }
        public string Title { get; set }
        public string Desctription { get; set }
    }
    public ActionResult GetActiveWorkItems2([DataSourceRequest]DataSourceRequest request)
    {
        using (TaskManagerContext context = new TaskManagerContext())
        {
            List<WorkItem> list = context.WorkItems.Where(x => x.IsActive == true).ToList();
            List<WorkItemViewModel> dataObjects = new List<WorkItemViewModel>();
            foreach (WorkItem workItem in list)
            {
                dataObjects.Add(new WorkItemViewModel { Title = workItem.Title, Description = workItem.Description });
            }
            return Json(dataObjects.ToDataSourceResult(request));
        }
    }
    <div>
        @(Html.Kendo().Grid<ViewModelNamespace.WorkItemViewModel>()
            .Name("grid")
            .HtmlAttributes(new { style = "height:380px;" } )
            .Sortable()
            .Pageable()
            .DataSource(dataSource => dataSource.Ajax().Read(read => read.Action("GetActiveWorkItems", "Home")))
            .Columns(columns =>
                {
                    columns.Bound(workItem => workItem.ID).Hidden();
                    columns.Bound(workItem => workItem.Title);
                    columns.Bound(workItem => workItem.Description);
                }
            )
        )
    </div>

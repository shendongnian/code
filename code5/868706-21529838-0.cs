    using Kendo.Mvc.Extensions;
    
    .....
    
            public ActionResult TimberData_Read([DataSourceRequest]DataSourceRequest request)
            {
                var grades = new List<TimberGrades>();
                grades.Add(new TimberGrades() { TimberGrade = "C14", BendingParallelToGrain = 4.1 });
                grades.Add(new TimberGrades() { TimberGrade = "C16", BendingParallelToGrain = 5.3 });
    
                IQueryable<TimberGrades> res = grades.AsQueryable<TimberGrades>();
                DataSourceResult res1 = res.ToDataSourceResult(request);
                return Json(res1, JsonRequestBehavior.AllowGet);
            }
    
    ....
    
    and in the view
    
    
            <p>
                <div id="DivTimberGradeGrid">
                    @(Html.Kendo().Grid<TimberBeamCalculator.Models.TimberGrades>()
                        .Name("TimberGradeGrid")
                        .DataSource(ds => ds
                                        .Ajax()
                                        .Read(r => r.Action("TimberData_Read", "Calculator"))   
                        )
                        .Columns(c=> 
                                {
                                    c.Bound(t => t.TimberGrade);
                                    c.Bound(t => t.BendingParallelToGrain);
                                }
                        )
                    )
    
                 
                </div>
            </p>

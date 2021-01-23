     @(Html.When(JqueryBind.Click)
           .OnSuccess(dsl =>
                      { 
              dsl.Self().Core().JQuery.Attributes.AddClass("progress-success")
                 .If(r => r.Is(() => !Selector.JS.Confirm("Yes or No")));           
                       } )
           .AsHtmlAttributes()
           .ToButton("Are you sure ?"))

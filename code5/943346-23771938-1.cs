    @model PostMessageViewModel
    
    @{
        Html.EnableClientValidation(true);
        Html.EnableUnobtrusiveJavaScript(true);
    }
    @using (Html.BeginUmbracoForm<JobSurfaceController>("HandlePostMessage", new { enctype = "multipart/form-data" }))
    {
        @Html.AntiForgeryToken()
        @Html.ValidationSummary(true)       
    
        @Html.Hidden("SomeField")
    
        <p>
            @Html.EditorFor(model => model.Message)
            @Html.ValidationMessageFor(model => model.Message)
        </p>
    
        <p>
            @Html.LabelFor(model => model.File)
            @Html.TextBoxFor(x => x.File, new { type = "file" })
        </p>
        <p><button class="button">Post Message</button></p>
    }

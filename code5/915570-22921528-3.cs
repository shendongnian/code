    @using System
    @using System.Linq
    @using TimeTable.GenericRepository
    @model TimeTable.Models.GroupViewModel
    
    @{
        //it's better to move the next line to a Controller later
        ViewBag.GroupId = new SelectList(new GroupRepository().Get().ToList(), "Id", "Code", Model.GroupId);
    
        ViewBag.Title = "Index";
        Layout = "~/Views/Shared/_LayoutBootstrap.cshtml";
    }
    
    <h2>Index</h2>
    <hr />
    
    @using (Html.BeginForm())
    {
        @Html.AntiForgeryToken()
        <div class="form-horizontal">
            @Html.ValidationSummary(true)
    
            <div class="form-group">
                @Html.LabelFor(model => model.GroupId, "Group is: ", new { @class = "control-label col-md-2" })
                <div class="col-md-10">
                    @Html.DropDownList("GroupId", String.Empty)
                    @Html.ValidationMessageFor(model => model.GroupId)
                </div>
            </div>
    
            @Html.ListBoxFor(m => m.Subjects, Model.SubjectItems, new { @id = "e", @style = "width:80%; " })
            <br /><br />
            <input type="submit" value="Generate" class="btn btn-default" />
        </div>
    }
    
    @* ReSharper disable once Razor.SectionNotResolved *@
    @section Scripts {
        @Styles.Render("~/Content/select2")
        @Scripts.Render("~/bundles/select2")
    
        <script type="text/javascript">
            $(function () { $("#e").select2(); });
        </script>
    }

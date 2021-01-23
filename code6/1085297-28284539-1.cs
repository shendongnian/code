    <script>
        var Namespace = Namespace || {};
    
        Namespace.Allocation = @Html.Raw(Json.Encode(YourProject.Namespace.To.AllocationInformation));
    
        $(document).ready(function () {
            var data = @Html.Raw(Json.Encode(Model));
            Namespace.Application.Init(data);
        });
    </script>

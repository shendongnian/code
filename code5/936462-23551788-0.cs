    **<script type="text/javascript">
        //@@mesagerowbound.js        
    
        function OnRowDataBound(e) {
            var grid = $(this).data('tGrid');
            var row = e.row;
            var dataItem = e.dataItem;
            var html = e.dataItem.MessageText;
            $(row).find(".messagetextcolumn").html(html);
        }
        </script>**
    
    @{Html.Telerik().Grid<LARHC.Web.Models.MessageViewModel>()
        .Name("MessageGrid")
        .Columns(columns =>
        {
            columns.Bound(m => m.Id).Hidden().HtmlAttributes(new { @class = "messageid" });
            columns.Bound(m => m.MessageType);
            columns.Bound(m => m.MessageTitle);
            **columns.Bound(m => m.MessageText).Width(100).HtmlAttributes(new { @class = "messagetextcolumn" });**
            columns.Bound(m => m.ActivationDate).Format("{0:MM/dd/yyyy}");
            columns.Bound(m => m.ExpirationDate).Format("{0:MM/dd/yyyy}");
            columns.Bound(m => m.Status).Title("Status");
            columns.Bound(m => m.UserName);
                    columns.Command(commands =>
            {
                commands.Edit()
                    .ButtonType(GridButtonType.ImageAndText);
                commands.Delete()
                .ButtonType(GridButtonType.ImageAndText);
            })
                            .HtmlAttributes(new { @class = "namecmdcolumn" })
                            .Width(50)
                            .Title("Commands");
        })
        .DataBinding(dataBinding =>
        {
            dataBinding.Ajax()
                .Select("GetMessages", "Admin")
                .Insert("NewMessage", "Admin")
                .Update("SaveMessage", "Admin")
                .Delete("DeleteMessage", "Admin");
        })
           
            .ClientEvents(events => events
                .OnEdit("onMessageEdit")
                .OnRowDataBound("OnRowDataBound")
                )
        .Render();
    }

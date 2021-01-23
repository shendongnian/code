    @Html.ActionLink(
        "Download PDF", 
        "PDF", 
        new { 
            AccID = Model.Item1.AccID,
            fkrecordID = Model.Item2[i].fkrecordID
        }, 
        new { 
            class = "btn btn-primary", 
            id = "pdf-download" 
        }
    );
    

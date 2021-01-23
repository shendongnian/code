    @model List<LoUCore.Models.Artifact>
    @{    
       var grid = new WebGrid(Model);
    }
    
    @grid.GetHtml(columns: grid.Columns(
        grid.Column("Filepath", header: "Sprite", format: x => 
            ((Func<dynamic, object>)(@<text><img src="@x.Filepath"></img></text>)).Invoke(x)
        )
    ))

    @using (Html.BeginForm("TigerTrail", "Awards", FormMethod.Post, new { @class = "form-horizontal" }))
    {
        for (int i = 0; i < Model.Count; i++)
        {
            @Html.EditorFor(x => x[i].FirstName)
            for (int j = 0; j < Model[i].TigerTrail.TigerTrailElectivedBadges.Count; ++j)
            {
                @Html.EditorFor(x => x[i].TigerTrail.TigerTrailElectivedBadges[j].Name)
            }
        }      
        <input type="submit" value="submit" />
    }

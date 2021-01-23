    @Html.ActionLink(this.LocalResources("Use"), VIA.Enums.ActionName.UseTemplate.GetStringValue(), 
    new { Id = "0", allPurposePrettyId = item.Id })
    @using (Html.BeginForm("SubmitBid", "Tender", 
    new { id = Model.Id, allPurposePrettyId = "0" }, FormMethod.Get, null))
    {
    <div style="text-align: center; margin: 20px 0 0 0">
        <button class="btn btn-large btn-primary" type="submit">@this.LocalResources("Bid.Text")</button>
    </div>
    }

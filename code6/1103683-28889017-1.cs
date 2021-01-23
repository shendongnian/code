    @model CampaignManager.Models.CharacterViewModel
    @using (Html.BeginForm())
    {
      <table>
        @Html.EditorFor(model => model.CharacterAbilityScores, new { AbilityScoresSelectList = Model.AbilityScoresSelectList })
      </table>
    }

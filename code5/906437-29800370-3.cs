	@model SampleModel
	<table>
		@for (var i = 0; i < Model.Items.Count; i++)
		{
			<tr>
				<td>       
					@Html.HiddenFor(m => Model.Items[i].Id)
					@Html.TextBoxFor(m => Model.Items[i].Name)
				</td>
			</tr>
		}
	</table>

	@model IList<PAL.Intranet.Models.MonitorDetailModel>
	<div>
		@for (int i = 0; i < @Model.Count(); i++)
		{
			string imageSource = string.Empty;
			switch (Model[i].AlertState) { 
				case PAL.Intranet.Models.AlertState.OK:
					imageSource = PAL.Intranet.Models.AlertStateImage.OK ;
					break;
				case PAL.Intranet.Models.AlertState.Alert:
					imageSource = PAL.Intranet.Models.AlertStateImage.Alert
					break;
				...
			}
			@if (i % 5 == 0)
			{
				<table>           
			}
			<tr>
				<td><img src="@imageSource" width="24" height="24"/></td>
				<td><b>@Model[i].Item:</b></td>
				<td style="padding:0 0 0 15px;">@Model[i].TaskItem.ToString():&nbsp;&nbsp;</td>
				<td>@(Model[i].Output != null ? @Model[i].Output :@Model[i].AlertState.ToString())</td>
				<td>@Model[i].Captured</td>
			</tr>
			
			@if (i % 5 == 0)
			{             
				</table>
			}
		}
	</div>

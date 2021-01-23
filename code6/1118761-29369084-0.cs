    @for (int i = 0; i < @Model.Count(); i++)
        {
            <table>
                <tr>
                    @if (i % 5 == 0)
                    {
                        <td>
                    }
    
                    <td><img src="@if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.OK)
                                  { @PAL.Intranet.Models.AlertStateImage.OK }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Alert)
                                  { @PAL.Intranet.Models.AlertStateImage.Alert }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Warning)
                                  { @PAL.Intranet.Models.AlertStateImage.Warning }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Critical)
                                  { @PAL.Intranet.Models.AlertStateImage.Error }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Error)
                                  { @PAL.Intranet.Models.AlertStateImage.Error }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Unknown)
                                  { @PAL.Intranet.Models.AlertStateImage.Unknown }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Online)
                                  { @PAL.Intranet.Models.AlertStateImage.OK }
                                  else if (@Model[i].AlertState == PAL.Intranet.Models.AlertState.Offline)
                                  { @PAL.Intranet.Models.AlertStateImage.Error }"                                
                              width="24" height="24"/></td>
                    <td><b>@Model[i].Item:</b></td>
                    <td style="padding:0 0 0 15px;">@Model[i].TaskItem.ToString():&nbsp;&nbsp;</td>
                    <td>@if (@Model[i].Output != null)
                        { @Model[i].Output }
                        else
                        { @Model[i].AlertState.ToString() }</td>
                    <td style="padding:0 0 0 15px;">Captured:&nbsp;&nbsp;</td>
                    <td>@Model[i].Captured</td>
    
                    @if (i % 5 == 0)
                    {
                        </td>
                    }
    
                </tr>
            </table>
        }

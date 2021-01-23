     @model IList<PAL.Intranet.Models.MonitorDetailModel>
        <div>       
            @for (int i = 0; i < @Model.Count(); i++)
            {
                if (string.IsNullOrWhiteSpace(@Model[i].Output))
                {
                    Model[i].Output = @Model[i].AlertState.ToString();
                }
        
                string image = string.Empty;
                switch (@Model[i].AlertState)
                {
                    case PAL.Intranet.Models.AlertState.OK:
                        image = PAL.Intranet.Models.AlertStateImage.OK;
                        break;
                    case PAL.Intranet.Models.AlertState.Warning:
                        image = PAL.Intranet.Models.AlertStateImage.Warning;
                        break;
                    case PAL.Intranet.Models.AlertState.Critical:
                        image = PAL.Intranet.Models.AlertStateImage.Error;
                        break;
                    case PAL.Intranet.Models.AlertState.Error:
                        image = PAL.Intranet.Models.AlertStateImage.Error;
                        break;
                    case PAL.Intranet.Models.AlertState.Unknown:
                        image = PAL.Intranet.Models.AlertStateImage.Unknown;
                        break;
                    case PAL.Intranet.Models.AlertState.Online:
                        image = PAL.Intranet.Models.AlertStateImage.OK;
                        break;
                    case PAL.Intranet.Models.AlertState.Offline:
                        image = PAL.Intranet.Models.AlertStateImage.Error;
                        break;
                    default:
                        image = PAL.Intranet.Models.AlertStateImage.Unknown;
                        break;
                }
        
                if (i % 5 == 0)
                {
                    @:<table>           
                }
                <tr>
                <td><img src="@image" width="24" height="24"/></td>
                <td><b>@Model[i].Item:</b></td>
                <td style="padding:0 0 0 15px;">@Model[i].TaskItem.ToString():&nbsp;&nbsp;</td>
                <td>@Model[i].Output</td>
                </tr>
                if (i % 5 == 0)
                {
                    @:</table>
                }
            }
        </div>

    @for(var i = 0; i < Model.CommonMatches.Count; i ++)
    {
                <div>
                    @using (Html.BeginForm("AcceptAppointment", "Appointment", FormMethod.Post)
                    {
                    @Model.CommonMatches[i].StartDateTime <br/>
                    @Model.CommonMatches[i].EndDateTime <br/>
                    
                    @for(var j = 0; Model.CommonMatches[i]; j++)
                    {
                          @Html.HiddenFor(m => Model.CommonMatches[i]AvailableAttendees[j].Prop1)<br/>
                          @Html.HiddenFor(m => Model.CommonMatches[i]AvailableAttendees[j].Prop2)<br/>
                    }
    
                     <input type="submit" value="Accept" />
            </div>
            }
    }

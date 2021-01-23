    @using (Html.BeginForm("Update", "Home", FormMethod.Post)) { 
    foreach (MvcMusicStore.Models.Service svc in Model)
                {
    
            @svc.ServiceName    @Html.CheckBox(svc.ServiceName, svc.isChecked); 
        <br/>
    
                }
                <input type="submit" value="submit"/>
    }

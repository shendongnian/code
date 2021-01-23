        @using UI.Shared.Utils
    @model IEnumerable<string>
        @{
            var forms = CustomFormUtil.GetCustomMetaPartial2(Model);
            var result = forms.Select(x => x.Model);  
        }
    
                          
        @using (Html.BeginForm(MVC.Service.NewOrderRequest.Index(new TdlMasterModel()), FormMethod.Post))
            {
                foreach (var form in forms)
                {
                    { Html.RenderPartial(form.View, form.Model); }
                }
                <p style="clear: both">
                    <input id="submitNOR" type="submit" value="Submit" style="float: right" />
                </p>
            }

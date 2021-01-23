    @model  DropDownValues
    @{
        string initial = null;
    
        if (Model != null && !string.IsNullOrWhiteSpace(Model.InitialValue))
        {
            initial = Model.InitialValue;
        }
        
        object attrributes;
    }
    
    @{if (Model != null && Model.Items != null && Model.Items.Count() > 0)
      {
          if (Model.Required)
          {
              attrributes = new
              {
                  data_val_required = Model.RequiredValidationMessage,
                  data_val = "true"
              };
          }
          else
          {
              attrributes = null;
          }
          
        @Html.DropDownListFor(x => x.SelectedValue,
        new SelectList(Model.Items, "Value", "Text"), initial, attrributes)
      }
    }

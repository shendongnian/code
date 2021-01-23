    private void Register_CheckAllControl_JScript()
        {
            // THIS IS A WORKAROUND FOR WHEN TWO OF THE SAME CUSTOM CONTROL LIVE ON THE SAME PAGE, EACH CONTROL'S JAVASCRIPT MUST SPECIFY THE ID OF THE CONTROL TO AFFECT
            if (gridPublishers.HeaderRow != null)
            { 
                CheckBox chkAll = gridPublishers.HeaderRow.FindControl("chkSelectAll") as CheckBox;
                if (chkAll != null)
                {
                    if (this.BindSource == Enumerators.BindSource.DynamicFromSession)
                    {
                        chkAll.Attributes.Add("onclick", "SelectAllCheckboxes(this,'GridSelectedPublishers');");
                    }
                    else
                    {
                        chkAll.Attributes.Add("onclick", "SelectAllCheckboxes(this,'GridPublishers');");
                    }
                }
            }
        }

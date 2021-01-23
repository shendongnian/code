    public void ListControls(ControlCollection controls, List<Control> controlsFound)
        {
            foreach (var control in controls.OfType<Control>())
            {
                if (control is IAttributeAccessor)
                {
                    controlsFound.Add(control); //Error (Invalid argument to Add method)
                    ListControls(control.Controls, controlsFound);
                }
            }
        } 

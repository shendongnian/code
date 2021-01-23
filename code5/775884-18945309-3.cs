    protected IList<ControlGroup> ControlGroups
    {
        get
        {
            return new List<ControlGroup>
            {
                new ControlGroup { Button = button1, CheckBox = checkbox1 },
                new ControlGroup { Button = button2, CheckBox = checkbox2 },
                new ControlGroup { Button = button3, CheckBox = checkbox3 }
                // etc.
            };
        }
    }

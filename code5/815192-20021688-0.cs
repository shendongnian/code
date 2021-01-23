    Binding bind = new Binding("BackColor", person, "IsOdd");
    bind.Format += (s, e) => {
       e.Value = (bool)e.Value ? Color.Green : Color.Red;
    };
    control.DataBindings.Add(bind);

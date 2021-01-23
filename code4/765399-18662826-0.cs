    public void CloneBinding(Control control, Binding bind){
       Binding bind = new Binding(bind.PropertyName, bind.DataSource, bind.BindingMemberInfo.BindingMember);
       control.DataBindings.Add(bind);
    }
    //Use it
    CloneBinding(ChildControl, ParentControl.DataBindings[0]);

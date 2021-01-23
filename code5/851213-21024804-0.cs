    var item = new Something() { Prop = Target.Student | Target.Professor };
    context.Save();
    
    var item2 = context.GetSomething();
    if (item2.Prop.HasFlag(Target.Professor) && item2.Prop.HasFlag(Target.Student))
    {
       // WOW!
    }

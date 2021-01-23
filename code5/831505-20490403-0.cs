    <Style x:Key="RoundButtonStyleKey" TargetType="{x:Type Button}">
    //Your Style goes here..
    </Style>
     Button btnb = new Button();
     btnb.Name = "b" + a.Key.ToString();
     btnb.MinHeight = 100;
     btnb.MinWidth = 100;
    
     btnb.Style = Application.Current.FindResource(RoundButtonStyleKey) as Style;

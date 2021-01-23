    public class MyMap : Map
    {
      public static readonly BindableProperty LocationsProperty = BindableProperty.Create<MyMap, List<string>>(x => x.Locations, new List<string>());
      public static readonly BindableProperty PinTappedCommandProperty = BindableProperty.Create<MyMap, Command>(x=>x.PinTapped, null);
      public MyMap(List<string> locations)
      {
        Locations = locations;
        PinTapped = new Command(async (x) =>
        {
          await Navigation.PopModalAsync();
          await Navigation.PushAsync(SomeNewPage(x));
        });
      }
      public List<string> Locations
      {
        get { return (List<string>)GetValue(LocationsProperty); }
        set { SetValue(LocationsProperty, value); }
      }
      public Command PinTapped 
      {
        get { return (Command) GetValue(PinTappedCommandProperty); }
        set { SetValue(PinTappedCommandProperty, value);}
      }
    }

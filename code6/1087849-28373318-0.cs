    public Apple Apple { get; set; }
    public Banana Banana { get; set; }
    public Cherry Cherry { get; set; }
    ...
    void OnLoad() {
      SetBinding(
        "Banana",
        new Binding("Apple") {
          Converter = (IValueConverter) FindResource("AppleToBananaConverter"),
          Mode = BindingMode.OneWay
        }
      );
      SetBinding(
        "Cherry",
        new Binding("Banana") {
          Converter = (IValueConverter) FindResource("BananaToCherryConverter"),
          Mode = BindingMode.OneWay
        }
      );
    }

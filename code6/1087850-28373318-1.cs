    Apple Apple { get; set; }
    Cherry Cherry { get; set; }
    ...
    void OnLoad() {
      SetBinding(
        "Cherry",
        new Binding("Apple") {
          Converter = (IValueConverter) FindResource("AppleToCherryConverter"),
          Mode = BindingMode.OneWay
        }
      );
    }

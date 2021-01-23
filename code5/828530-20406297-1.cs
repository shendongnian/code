    static string GetStringValue2(Enum value) {
     ....
    }
    public static List<SelectListItem> GetFlagsSelectList<T>(int? selectedValue) where T : struct {
      var items = new List<SelectListItem>();
      foreach (T value in Enum.GetValues(typeof(T))) {
        var stringValue = GetStringValue2((Enum)(object)value);
        items.Add(new SelectListItem {
          Text = Enum.GetName(typeof(T), value),
          Value = Convert.ToInt32(value).ToString(),
          Selected = selectedValue.HasValue && selectedValue.Value == Convert.ToInt32(value)
        });
      }
      return items;
    }

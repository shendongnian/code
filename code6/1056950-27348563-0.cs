    public class EatenMealVM
    {
      [Display(Name="Nazwa posiłku")]
      public string MealName { get; set; }
      [Display(Name = "Typ posiłku")]
      [Required(ErrorMessage = "Please select a meal")]
      public int? MealTypeID { get; set; }
      [Display(Name = "Porcja (g)")]
      public double Serving { get; set; } // is this really double?
      [Display(Name = "Data spożycia")]
      [DataType(DataType.Date)]
      public DateTime Date { get; set; }
      public SelectList MealTypeList { get; set; }
    }

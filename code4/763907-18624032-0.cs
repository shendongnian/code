    public enum ColourType
    {
      Flat,
      Metallic
    }
    public class Car
    {
      public void Repaint(int red, int green, int blue, ColourType colourType)
      {
        // TODO: Add some validation logic and business logic.
      }
    }
    public class RepainInMetallicModel
    {
      [Required]
      [Range(0, 100)]
      public int Red { get; set; }
      [Required]
      [Range(0, 100)]
      public int Green { get; set; }
      [Required]
      [Range(0, 100)]
      public int Blue { get; set; }
    }
    public class RepaintInFlatModel
    {
      [Required]
      [Range(0, 255)]
      public int Red { get; set; }
      [Required]
      [Range(0, 255)]
      public int Green { get; set; }
      [Required]
      [Range(0, 255)]
      public int Blue { get; set; }
    }
    public class CarController
    {
      public ActionResult RepaintInMetallic(RepainInMetallicModel model)
      {
        if (ModelState.IsValid)
        {
          var car = _carsRepository.Find(model.Id);
          var.Repaint(model.Red, model.Green, model.Blue, ColourType.Metallic);
          _carsRepository.Save(car);
        }
        return View();
      }
      public ActionResult RepaintInFlat(RepaintInFlatModel model)
      {
        if (ModelState.IsValid)
        {
          var car = _carsRepository.Find(model.Id);
          var.Repaint(model.Red, model.Green, model.Blue, ColourType.Flat);
          _carsRepository.Save(car);
        }
        return View();
      }
    }

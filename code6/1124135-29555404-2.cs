    using (var context = new YourContext())
    {
        var selectedInteractiveObject = context.InteractiveObjects.FirstOrDefault(x => x.Id == 1);
        var indicator = new Indicator { Name = "Test"};
        selectedInteractiveObject.Indicator = indicator;
        
        context.SaveChanges(); 
    }

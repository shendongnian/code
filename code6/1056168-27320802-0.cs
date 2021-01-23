    public class DateTimeValidation : FormHandler {
       public override void Validating(ValidatingContext context) {
          if (context.FormName == "EventRangeForm") {
             var min = context.ValueProvider.GetValue("DateFrom");
             //validate...
             context.ModelState.AddModelError("DateFrom", "You did it wrong!");
          }
       }
    }

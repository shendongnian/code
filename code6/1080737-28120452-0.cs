    public class OneWheelchairPerTrainAttribute : ValidationAttribute
    {
      public override bool IsValid(object value, ValidationContext context)
      {
        Object instance = context.ObjectInstance;
        Type type = instance.GetType();
        // Here is your timetableId
        Object timeTableId = type.GetProperty("TimetableId ").GetValue(instance, null);
        //Do validation ...
       }
    }

    public class Grievance: IValidatebleObject
    {
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
         { 
             if (FileDate < Incident.IncidentDate 
                ||(HearingDate.HasValue && HearingDate.Value < Incident.IncidentDate)) 
             { 
                 yield return new ValidationResult 
                  ("Dates invalid", 
                   new[] { "FileDate", “HearingDate”, "Incident.IncidentDate" }); 
             } 
         }  
    }

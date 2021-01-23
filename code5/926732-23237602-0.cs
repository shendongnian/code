     public class Models
         {
             public string Duration { get; set; }
             public string Dose { get; set; }
         }
 
    List<Models> lstModels = new List<Models>();    
    lstModels.Add(new Models { Duration = "101:12" });
    lstModels.Add(new Models { Duration = "13:24" });
    lstModels.Add(new Models { Duration = "19:56" });                       
    List<Models> sortedList = (from models in lstModels
                                 select new Models
                                   {
                                     Dose = models.Dose,
                                     Duration = models.Duration.Replace(':','.')}).ToList().OrderBy(x=>Convert.ToDouble(x.Duration)).ToList();

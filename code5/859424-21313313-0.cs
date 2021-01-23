    using System.Web.Script.Serialization;
    using Newtonsoft.Json;
    
    ...
    
    var timeList= db.DocumentType.ToList();
    
    ViewBag.ResponseTimes= new JavaScriptSerializer().Serialize(
                    JsonConvert.SerializeObject(new
                    {
                        times= (from obj in timeList
                                   select new { DocumentTypeId= obj.DocumentTypeId, ResponseTime= obj.ResponseTime})
                    }, Formatting.None));

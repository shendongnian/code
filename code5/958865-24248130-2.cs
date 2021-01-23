        public class Service
        {
        public string ServiceName {get; set;}
        public bool isChecked {get;set;}
    
        }
        ....
        public List<Service> ServicesList{ get; set; }
        ....
        //that controller will collect data posted from view 
        //(your form will post only checked checkboxes)
    	[HttpPost]
            public JsonResult Update(FormCollection services)
    		{
    
                foreach (string item in services)
                {
                    System.Diagnostics.Debug.WriteLine(item);
                }
    
                return Json(services);
    		
    		
    		}

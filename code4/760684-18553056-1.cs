    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace MedAvail.Applications.MedProvision.Web.Util
    {
        public class SelectListItemHelper
        {
            public static IEnumerable<SelectListItem> GetProvincesList()
            {
                IList<SelectListItem> items = new List<SelectListItem>
                {
                    new SelectListItem{Text = "California", Value = "B"},
                    new SelectListItem{Text = "Alaska", Value = "B"},
                    new SelectListItem{Text = "Illinois", Value = "B"},
                    new SelectListItem{Text = "Texas", Value = "B"},
                    new SelectListItem{Text = "Washington", Value = "B"}
    
                };
                return items;
            }
    
    
            public static IEnumerable<SelectListItem> GetCountryList()
            {
                IList<SelectListItem> items = new List<SelectListItem>
                {
                    new SelectListItem{Text = "United States", Value = "B"},
                    new SelectListItem{Text = "Canada", Value = "B"},
                    new SelectListItem{Text = "United Kingdom", Value = "B"},
                    new SelectListItem{Text = "Texas", Value = "B"},
                    new SelectListItem{Text = "Washington", Value = "B"}
    
                };
                return items;
            }
    
    
        }
    }

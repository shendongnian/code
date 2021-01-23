            public class Address
            {
                public Address()
                {
                    Regions  = new List<SelectListItem>();
                }
                //Your Address Properties
                public int SelectedRegionId {get; set;}
                public IEnumerable<SelectListItem> Regions {get; set;}
                //You can fill the Regions list in the controller, or in the contructor
                public IEnumerable<SelectListItem> CreateRegionsSelectList()
                {
                    var regions = new List<SelectListItem>();
                    var domainRegions = // Get your regions from Repository;
                    foreach (var region in domainRegions)
                        regions.Add(new SelectListItem { Text = region.Name, Value = region.Id};
                }
            }

			//Assuming you have this class for your destinationn object
			public class iPadClass
			{
			    public string ipad;
				public string other;
			}
			
			List<iPadClass> ipadList = new List<iPadClass>();
			//since your source is not a typed class
            IEnumerable dataList = getDataFromWebAPI() 
            foreach (var row in dataList)
            {
                    ipadList.Add(new iPadClass() { ipad = row[0], other = row[1]});
                   //or whichever works for you
                    ipadList.Add(new iPadClass() { ipad = row.items[0], other = row.items[1]});
                }
            }

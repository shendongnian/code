    		public void PerformTest() {
    			var list1 = new List<Dictionary<string, MyCustomType>>();
    			var list2 = new List<Dictionary<string, MyCustomType2>>();
    
    			list1 = new List<Dictionary<string, MyCustomType>> {
    				new Dictionary<string, MyCustomType> {
    					{
    						"key1",
    						new MyCustomType {
    							ID = "3",
    							Date = "12/28/2013",
    							Target = "1"
    						}
    					}, {
    						"key2",
    						new MyCustomType {
    							ID = "4",
    							Date = "12/30/2013",
    							Target = "33"
    						}
    					}
    				}
    			};
    
    			list2 = new List<Dictionary<string, MyCustomType2>> {
    				new Dictionary<string, MyCustomType2> {
    					{
    						"key3",
    						new MyCustomType2 {
    							ID = "3",
    							Date = "12/28/2013",
    							Target = "1",
    							ASO = "100",
    							Below = "50"
    						}
    					}, {
    						"key4",
    						new MyCustomType2 {
    							ID = "4",
    							Date = "12/28/2013",
    							Target = "1",
    							ASO = "100",
    							Below = "50"
    						}
    					}
    				}
    			};
    
    			var innerList1 = list1.SelectMany(x => x.Values);
    			var innerList2 = list2.SelectMany(x => x.Values);
    
    			var list3 = innerList1
    				.Join(innerList2, x => x.ID, x => x.ID, (x, y) => new MyCustomType2 {
    					ASO = y.ASO,
    					Below = y.Below,
    					Date = x.Date,
    					ID = x.ID,
    					Target = x.Target
    				});
    		}
    
    		public class MyCustomType {
    			public string ID = "3";
    			public string Date = "12/28/2013";
    			public string Target = "1";
    		}
    
    		public class MyCustomType2 {
    			public string ID = "3";
    			public string Date = "12/28/2013";
    			public string Target = "1";
    			public string ASO = "100";
    			public string Below = "50";
    		}

    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace RepeaterTestOne
    {
        public static class MyDataClass
        {
            public static void BindTable(Repeater rpt, MyEnum mySelection = MyEnum.AllItems)
            {
    
                //Replace this part with custom sql
                List<MyData> lst = new List<MyData>()
                {
                    new MyData{ID=1, Name="Item 1"},
                    new MyData{ID=2, Name="Item 2"},
                    new MyData{ID=3, Name="Item 3"},
                    new MyData{ID=4, Name="Item 4"},
                    new MyData{ID=5, Name="Item 5"}
                };
                switch (mySelection)
                {
                    case MyEnum.FirstOne:
                        lst = new List<MyData>(){new MyData{ID=1, Name="Item 1"}};
                        break;
                    case MyEnum.FirstFour:
                        lst = new List<MyData>()
                        {
                            new MyData{ID=1, Name="Item 1"},
                            new MyData{ID=2, Name="Item 2"},
                            new MyData{ID=3, Name="Item 3"},
                            new MyData{ID=4, Name="Item 4"}
                        };
                        break;
                    default:
                        lst = new List<MyData>()
                        {
                            new MyData{ID=1, Name="Item 1"},
                            new MyData{ID=2, Name="Item 2"},
                            new MyData{ID=3, Name="Item 3"},
                            new MyData{ID=4, Name="Item 4"},
                            new MyData{ID=5, Name="Item 5"}
                        };
                        break;
                }
                //Replace this part with custom sql
    
                rpt.DataSource = lst;
                rpt.DataBind();
            }
    
        }
        public class MyData
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }

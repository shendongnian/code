    using System.Collections.Generic;
    using System.Web.UI.WebControls;
    
    namespace RepeaterTestOne
    {
        public static class MyDataClass
        {
            public static void BindTable(Repeater rpt)
            {
                var lst = new List<MyData>()
                {
                    new MyData{ID=1, Name="Item 1"},
                    new MyData{ID=2, Name="Item 2"},
                    new MyData{ID=3, Name="Item 3"},
                    new MyData{ID=4, Name="Item 4"}
                };
    
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

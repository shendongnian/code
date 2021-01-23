    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace WpfApplication4
    {
        public class MyItemCollection : System.Collections.ObjectModel.ObservableCollection<MyItem>
        {
            public MyItemCollection()
            {
                Add(new MyItem() { MyText = "test", MyIsChecked = true });
                Add(new MyItem() { MyText = "test2", MyIsChecked = false  });
                Add(new MyItem() { MyText = "test3", MyIsChecked = false });
                Add(new MyItem() { MyText = "test4", MyIsChecked = true });
                this[0].MyInnerCollection.Add(new MyItem() { MyText = "innertest", MyIsChecked = true });
            }
        }
        public class MyItem
        {
            public MyItem()
            {
                _MyInnerCollection = new System.Collections.ObjectModel.ObservableCollection<MyItem>();
            }
            // Fields...
            private System.Collections.ObjectModel.ObservableCollection<MyItem> _MyInnerCollection;
            private bool _MyIsChecked;
            private string _MyText;
            public string MyText
            {
                get { return _MyText; }
                set
                {
                    _MyText = value;
                }
            }
            public bool MyIsChecked
            {
                get { return _MyIsChecked; }
                set
                {
                    _MyIsChecked = value;
                }
            }
            public System.Collections.ObjectModel.ObservableCollection<MyItem> MyInnerCollection
            {
                get
                {
                    return _MyInnerCollection;
                }
            }
    
        }
    }

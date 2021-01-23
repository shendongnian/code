        public abstract class GoodItem {
            protected GoodItem() { }
            private string _name;
            public virtual string Name { get { return string.Concat(Prefix, _name); } set { _name = value; } }
            protected virtual string Prefix { get; set; }
            public virtual int Id { get; set; }
            public virtual List<String> Settings { get; set; }
        }
        public class BasicItem : GoodItem {
            public BasicItem()
                : base() {
                    Prefix = "Basic";
            }
        }
        public class AdvancedItem : GoodItem {
            public AdvancedItem()
                : base() {
                    Prefix = "Advanced";
            }
        }
        public class ExpertItem : GoodItem {
            public ExpertItem()
                : base() {
                    Prefix = "Expert";
            }
        }
        public static T CreateNewItem<T>() where T : GoodItem {
            return Activator.CreateInstance<T>();
        }

        public class MListBox<T, M> : ListBox
            where T : class
            where M : class, new()
        {
            public void LoadList()
            {
                MyEvents<T, M>.LoadList("getList").ForEach(w => this.Items.Add(w));
            }
        }
        public void main(string[] args)
        {
            MListBox<object,STOCK> mb = new MListBox<object,STOCK>();
            mb.LoadList();
        }
        public static class MyEvents<T, M>
            where T : class
            where M : class, new()
        {
            public static M m;
            public static T t;
            public static List<T> LoadList(string _method)
            {
                m = new M();
                MethodInfo method = typeof(M).GetMethod(_method);
                List<T> ret = (List<T>)method.Invoke(m, null);
                return ret;
            }
        }

    public class Form1 : Form {
        public IList<MyObjectType> DataContext {
            get { return (IList<MyObjectType>)myBindingSource.DataSource; }
            set { myBindingSource.DataSource = value; }
        }
    }
    public class Form2 : Form {
        public IList<MyObjectType> DataContext {
            get { return (IList<MyObjectType>)myBindingSource.DataSource; }
            set { myBindingSource.DataSource = value; }
        }
    }

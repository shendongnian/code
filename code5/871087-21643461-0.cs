    using System.Linq;
    using Microsoft.Phone.Controls;
    using System.Collections.Generic;
    using System.ComponentModel;
    namespace PhoneApp1
    {
    public partial class TestPage : PhoneApplicationPage
    {
        public TestPage()
        {
            InitializeComponent();
            this.parentLB.ItemsSource = Grandparent1().ParentGroups;
        }
        public GrandParent Grandparent1()
        {
            List<Parent> ParentGroups = new List<Parent>();
            ParentGroups.Add(Parent1());
            ParentGroups.Add(Parent2());
            GrandParent gp = new GrandParent();
            gp.ParentGroups = ParentGroups;
            return gp;
        }
        public Parent Parent2()
        {
            Parent p = new Parent { Name = "Tom" };
            Child c1 = new Child { Name = "Tammy" };
            Child c2 = new Child { Name = "Timmy" };
            p.AddChild(c1);
            p.AddChild(c2);
            return p;
        }
        public Parent Parent1()
        {
            Parent p = new Parent { Name = "Carol" };
            Child c1 = new Child { Name = "Carl" };
            c1.HasHighSchoolDegree = true;
            c1.HasUniversityDegree = true;
            Child c2 = new Child { Name = "Karla" };
            p.AddChild(c1);
            p.AddChild(c2);
            return p;
        }
    }
    public class GrandParent : BindableBase
    {
        public List<Parent> ParentGroups { get; set; }
    }
    public class Parent : BindableBase
    {
        public string Name { get; set; }
        private List<Child> _children;
        public List<Child> Children
        {
            get { return this._children; }
            set { _children = value; }
        }
        public Parent()
        {
            _children = new List<Child>();
        }
        public void AddChild(Child child)
        {
            child.PropertyChanged += ChildOnPropertyChanged;
            _children.Add(child);
        }
        private void ChildOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            //if(propertyChangedEventArgs.PropertyName == "HasUniversityDegree");
            OnPropertyChanged("NumberOfChildrenWithDegrees");
        }
        private int _numberOfChildrenWithDegrees;
        public int NumberOfChildrenWithDegrees
        {
            get { return Children.Where(f => f.HasTwoDegrees).Count(); }
            set { _numberOfChildrenWithDegrees = value; }
        }
    }
    public class Child : BindableBase
    {
        public string Name { get; set; }
        public bool HasTwoDegrees
        {
            get { return HasHighSchoolDegree && HasUniversityDegree; }
        }
        private bool _hasUniversityDegree;
        public bool HasUniversityDegree
        {
            get { return this._hasUniversityDegree; }
            set
            {
                _hasUniversityDegree = value;
                OnPropertyChanged("HasTwoDegrees");
            }
        }
        private bool _hasHighSchoolDegree;
        public bool HasHighSchoolDegree
        {
            get { return this._hasHighSchoolDegree; }
            set
            {
                _hasHighSchoolDegree = value;
                OnPropertyChanged("HasTwoDegrees");
            }
        }
    }
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, string propertyName = null)
        {
            if (object.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    }

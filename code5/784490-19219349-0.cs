	public partial class Form2 : Form {
		public Form2() {
			InitializeComponent();
			// let the OLV know that a person node can expand 
			this.treeListView.CanExpandGetter = delegate(object rowObject) {
				return (rowObject is Person);
			};
			// retrieving the "things" from Person
			this.treeListView.ChildrenGetter = delegate(object rowObject) {
				Person person = rowObject as Person;
				return person.Things;
			};
			// column 1 shows name of person
			olvColumn1.AspectGetter = delegate(object rowObject) {
				if (rowObject is Person) {
					return ((Person)rowObject).Name;
				} else {
					return "";
				}
			};
			// column 2 shows thing information 
			olvColumn2.AspectGetter = delegate(object rowObject) {
				if (rowObject is Thing) {
					Thing thing = rowObject as Thing;
					return thing.Name + ": " + thing.Description;
				} else {
					return "";
				}
			};
			// add one root object and expand
			treeListView.AddObject(new Person("Person 1"));
			treeListView.ExpandAll();
		}
	}
	public class Person {
		public string Name{get;set;}
		public List<Thing> Things{get;set;}
		public Person(string name) {
			Name = name;
			Things = new List<Thing>();
			Things.Add(new Thing("Thing 1", "Description 1"));
			Things.Add(new Thing("Thing 2", "Description 2"));
		}
	}
	public class Thing {
		public string Name{get;set;}
		public string Description{get;set;}
		public Thing(string name, string desc) {
			Name = name;
			Description = desc;
		}
	}

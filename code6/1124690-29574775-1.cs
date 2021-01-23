	public class DomainObject {
		public int Id { get; set; }
	}
	public class Panel : DomainObject{
		public List<DrugClass> DrugClasses { get; set; }
	}
	public class DrugClass : DomainObject {
		public List<TestedDrug> TestedDrugs { get; set; }
		public List<Panel> Panels { get; set; }
	}
	public class TestedDrug : DomainObject {
		public List<DrugClass> DrugClasses { get; set; }
	}

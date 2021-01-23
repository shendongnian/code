        public class RecursiveControlEnumerator : RecursiveEnumerator, IEnumerator {
        	public RecursiveControlEnumerator(Control.ControlCollection controlCollection)
        		: base(controlCollection) { }
        	protected override ICollection GetChildCollection(object c) {
        		return (c as Control).Controls;
        	}
        }

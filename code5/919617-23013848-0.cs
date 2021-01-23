    public class Demo {
       private Dictionary<string, ListBox> _listboxes = new Dictionary<string, ListBox>();
       private void CreateListBoxWithName(string name) {
          var lb = new ListBox();
          _listboxes.add(name, lb);
          // do other stuff ...
       }
       private ListBox FindListBoxByName(string name) {
          return _listboxes[name];
       }
    }

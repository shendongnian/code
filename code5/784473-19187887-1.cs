    List<Component> _listEnabled = _listComp.Find(item => (item.enable == true));
    
    foreach(Component c in _listEnabled ){
       if(c._runOnce){
          c.Init();           // if at all possible, _runOnce should be set to false
          c._runOnce = false; // IN THE OBJECT, after calling Init();
       }
       c.Update();
    }

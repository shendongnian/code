    interface DataSource {
       List<String> GetData();
    }
    
    class Manipulator {
     private DataSource _source;
    
     public Manipulator(){ }
    
     public Manipulator(DataSource d) { _source = d; }
    
     pubic void ManipulateData(){
        var data = _source.GetData();
    
        // Do something with the data
     }
    }

    class cPoint {
        public cPoint(){
          //We just care about the Properties of type double
          props = GetType().GetProperties().Where(p=>p.PropertyType==typeof(double)).ToArray();
          ColumnCount = props.Length;
        }
        PropertyInfo[] props;
        public int ColumnCount {get;private set;}
        public double a {get;set}
        public double b {get;set;}
        public double c {get;set;}
        public double d {get;set;}
        public double this[int index]{
           get {
              if(index < 0 || index >= props.Length) throw new IndexOutOfRangeException();
              return (double)props[index].GetValue(this,null);
           }
           set {
              if(index < 0 || index >= props.Length) throw new IndexOutOfRangeException();
              props[index].SetValue(this, value, null);
           }
        }
    }
    var list1 = lst.Select(x=> {                    
                    cPoint output = new cPoint();
                    output[0] = x[0];
                    for(int i = 1; i < x.ColumnCount-1; i++){
                       output[i] = (x[i - 1] + x[i] + x[i + 1]) / 3;
                    }
                    return output;
                }).ToList();
    var list2 = lst.Select(x=> {
                    cPoint output = new cPoint();
                    output[0] = x[0];
                    for(int i = 1; i < x.ColumnCount-1; i++){
                       output[i] = x[i] - x[i - 1];
                    }
                    return output;
                }).ToList();

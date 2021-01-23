    public static IEnumerable<MyCVSModel> Converion(String FileName){
         var AllLines = System.IO.ReadAllLines(FileName);
         foreach(var i in AllLines){
            var Temp = i.Split('\t'); // Or any other delimiter
            if (Temp.Lenght >= 4){ // 4 is because you have 4 values in a row
               List<Double> TryConversion = new List<Double>();
               foreach(var x in Temp) {
                  if (IsDouble(x))
                     TryConversion.Add(Convert.ToDouble(x));
                  else
                     TryConversion.Add(0);
               }
               MyCVSModel Model = new MyCVSModel();
               Model.Number1 = TryConversion[0];
               Model.Number2 = TryConversion[1];
               Model.Number3 = TryConversion[2];
               Model.Number4 = TryConversion[3];
               yield return Model;
            }
         }
    }
    public static Boolean IsDouble(String Value) {
        Regex R = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
        return R.IsMatch(Value);
    }

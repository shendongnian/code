    public class FlyWeightInstance {
    
        private int value; //<- private field
        private static Dictionary<int,FlyWeightInstance> dic = new Dictionary<int,FlyWeightInstance>(); //<- private static cache
    
        private int FlyWeightInstance (int value) { // <-- private constructor
            this.value = value;
        }
    
        public static FlyWeightInstance (int value) {
            FlyWeightInstance res;
            if(!dic.TryGetValue(value,out res)) {
                res = new FlyWeightInstance(value);
                dic.Add(value,res);
            }
            return res;
        }
    
    }

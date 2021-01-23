        public void AddRange(object arg) {
            var arr = (Array)arg;
            for (int ix = ar.GetLowerBound(0); ix <= arr2.GetUpperBound(0); ++ix) {
                Debug.Print(arr.GetValue(ix, 1).ToString());
            } 
        }

        public void AddRange(object arg) {
            var arr = new Vba1DRange(arg);
            foreach (double elem in arr) {
                Debug.Print(elem.ToString());
            }
            // or:
            for (int ix = 0; ix < arr.Length; ++ix) {
                Debug.Print(arr[ix].ToString());
            }
            // or:
            var list = new List<double>(arr);
        }

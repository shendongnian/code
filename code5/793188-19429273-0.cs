            List<string> list1 = new List<string>();
            List<int> list2 = new List<int>();
            //...
            string separator = "\t";
            using (StreamWriter writer = new StreamWriter(fileName)){
                for (int i = 0; i<Math.Max(list1.Count, list2.Count); i++){
                    var element1 = i < list1.Count ? list1[i] : "";
                    var element2 = i < list2.Count ? list2[i].ToString() : "";
                    writer.Write(element1);
                    writer.Write(separator);
                    writer.WriteLine(element2);
                }
            }

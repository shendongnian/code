    using System.Linq;
    
    public static class Load {
        public static double[][] FromFile(string path) {
            var rows = new List<double[]>();
            foreach (var line in File.ReadAllLines(path)) {
                rows.Add(line.Split(new[]{' '}).Select(double.Parse).ToArray());
            }
            return rows.ToArray();
        }
    }

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            List<ColorMap> colorMaps = new List<ColorMap>()
            {
                new ColorMap(-999, -1, "FF0000"),
                new ColorMap(-0.99, -0.75, "FF3333")
                /* and so on*/
            };
            foreach (DataGridViewRow row in dataGridView1.Rows) {
                foreach (DataGridViewCell cell in row.Cells) {
                    double cellValue;
                    if (!double.TryParse(cell.Value.ToString(), out cellValue)) {
                        continue;//or whatever logic you want
                    }
                    ColorMap colorMap = colorMaps.SingleOrDefault(x => x.From <= cellValue && x.To >= cellValue);
                    if (colorMap == null) {
                        continue;//or whatever logic you want
                    }
                    ColorCode colorCode = new ColorCode(colorMap.Value);
                    cell.Style.BackColor = Color.FromArgb(colorCode.Red, colorCode.Green, colorCode.Blue);
                }
            }
        }
    }
    public class ColorMap {
        public double From { get; private set; }//lowest border
        public double To { get; private set; }//highest border
        public string Value { get; private set; }//color code
        public ColorMap(double from, double to, string value) {
            this.From = @from;
            this.To = to;
            this.Value = value;
        }
    }
    public class ColorCode {
        public string Color { get; private set; }
        public ColorCode(string code) {
            this.Color = code;
        }
        public int Red { get { return ConvertToInt(0, 1); } }
        public int Green { get { return ConvertToInt(2, 3); } }
        public int Blue { get { return ConvertToInt(4, 5); } }
        private int ConvertToInt(int index1, int index2) {
            if (Color == null || Color.Length != 6) {
                return 0;//or whatever logic you want
            }
            string hexValue = string.Format("{0}{1}", Color[index1], Color[index2]);
            int result;
            try {
                result = int.Parse(hexValue, NumberStyles.HexNumber);
            } catch {
                return 0;
            }
            return result;
        }
    }

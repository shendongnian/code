    public partial class Form1 : Form {
        // form have three controls  txtbx_id, txtbx_noofrecomm and button1.
        int[] d = new int[92162];
        string data = 
             "0\t762354\n"
            +"1\t645645\n"
            +"2\t4356743\n"
            +"3\t576899063\n"
            +"4\t64378\n";
        public Form1() {
            InitializeComponent();
            using (var fileuserori = new StringReader(data)) { // use StringReader instead of StreamReader
                string lineuserori = "";
                for (int klk = 0; klk <= 92159; klk++) {
                    lineuserori = fileuserori.ReadLine();
                    if (!string.IsNullOrEmpty(lineuserori)) {
                        // string[] valuesiesi = lineitemori.Split('\t');
                        string[] valuesiesi = lineuserori.Split('\t');
                        int useridori;
                        foreach (string value in valuesiesi) {
                            useridori = Convert.ToInt32(valuesiesi[1]);
                            d[klk] = useridori;
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e) {
            var userseq = -1;
            int sc = Convert.ToInt32(txtbx_id.Text);
            int n = Convert.ToInt32(txtbx_noofrecomm.Text);
            for (int yu = 0; yu <= 92161; yu++) {
                int wer = d[yu];
                if (wer == sc) {
                    userseq = yu;
                    break;
                }
            }
            if (userseq >= 0 && userseq <= 92161) {
                var results = new List<float>(1143600);
                for (int z = 0; z < 1143600; z++) {
                    // results.Add(dotproduct(userseq, z));
                }
                var sb1 = new StringBuilder();
                foreach (var resultwithindex in results.Select((r, index) => new { result = r, Index = index }).OrderByDescending(r => r.result).Take(n)) {
                    // sb1.AppendFormat(CultureInfo.InvariantCulture, "{0}: {1}", c[resultwithindex.Index], resultwithindex.result);
                    // sb1.AppendLine();
                }
                MessageBox.Show(sb1.ToString());
            }
            if (userseq < 0 || userseq > 92161) {
                MessageBox.Show("Error");
            }
        }
    }

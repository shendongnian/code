    protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                var numAlpha = new Regex(@"^(?<Numeric>[0-9]+)(?<Alpha>[a-zA-Z]+)(?<mnum>\d+)$");
                var input = TextBox1.Text;
                var match = numAlpha.Match(TextBox1.Text);
                var Amount = match.Groups["Numeric"].Value;
                var Operator = match.Groups["Alpha"].Value;
               
                    var index = Operator.Substring(Operator.Length - 1);
                    var MobileNum = input.Substring(input.IndexOf(index) + 1);
                
                var kk = numAlpha.Match(MobileNum).Groups["Alpha"].Value;
                if ((Operator.Length > 2) & ((numAlpha.Match(MobileNum).Groups["Alpha"].Value).Length != 0) || (MobileNum.Length > 10))
                {
                    Label1.Text = Amount;
                    Label3.Text = "invalid MobileNum";
                    Label2.Text = "invalid operator";
                }
                else if (((numAlpha.Match(MobileNum).Groups["Alpha"].Value).Length != 0) & (MobileNum.Length > 10))
                {
                    Label1.Text = Amount;
                    Label2.Text = Operator;
                    Label3.Text = "invalid MobileNum";
                }
                else if (Operator.Length > 2)
                {
                    Label1.Text = Amount;
                    Label2.Text = "invalid operator";
                    Label3.Text = MobileNum;
                }
                else
                {
                    Label1.Text = Amount;
                    Label2.Text = Operator;
                    Label3.Text = MobileNum;
                }
            }
            catch(Exception ex)
            {
                Label4.Text = "invalid input";
            }
        }
        
